using Presentacion_Supermercado.interfaces;
using Newtonsoft.Json;
using System.Text;

namespace Presentacion_Supermercado.implementaciones
{
    public class Comunicaciones : IComunicaciones
    {
        public string? Usuario { get; set; }

        public async Task<T> Ejecutar<T>(string url, object entidad)
        {
            url = "http://localhost:5041/" + url;

            var body = new StringContent(
                JsonConvert.SerializeObject(entidad), 
                Encoding.UTF8, "application/json");

            var cliente_http = new HttpClient();
            cliente_http.Timeout = new TimeSpan(0, 4, 0);

            if (!string.IsNullOrEmpty(Usuario))
                cliente_http.DefaultRequestHeaders.Add("Usuario", Usuario);

            var message = await cliente_http.PostAsync(url, body);

            var respuesta = await message.Content.ReadAsStringAsync();

            if (!message.IsSuccessStatusCode)
            {
                // La API responde con un mensaje claro (por ejemplo, por qué no se puede borrar)
                if (!string.IsNullOrWhiteSpace(respuesta) && respuesta.Length < 300 && !respuesta.StartsWith("<"))
                    throw new Exception(respuesta);
                throw new Exception("Error Comunicacion");
            }

            cliente_http.Dispose(); 
            cliente_http = null;

            // La API ya responde JSON válido: no se debe "limpiar" el texto, porque
            // dañaba el base64 de las imágenes (cambiaba + por "u002B").
            return JsonConvert.DeserializeObject<T>(respuesta)!;
        }
    }
}