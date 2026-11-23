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

            if (!message.IsSuccessStatusCode)
                throw new Exception("Error Comunicacion");

            var respuesta = await message.Content.ReadAsStringAsync();
            cliente_http.Dispose(); 
            cliente_http = null;

            respuesta = Replace(respuesta);
            return JsonConvert.DeserializeObject<T>(respuesta)!;
        }

        private string Replace(string resp)
        {
            return resp.Replace("\\\\r\\\\n", "")
                .Replace("\\r\\n", "")
                .Replace("\\", "")
                .Replace("\\\"", "\"")
                .Replace("\"", "'")
                .Replace("'[", "[")
                .Replace("]'", "]")
                .Replace("'{'", "{'")
                .Replace("\\\\", "\\")
                .Replace("'}'", "'}")
                .Replace("}'", "}")
                .Replace("\\n", "")
                .Replace("\\r", "")
                .Replace("    ", "")
                .Replace("'{", "{")
                .Replace("\"", "")
                .Replace("  ", "")
                .Replace("null", "''");
        }
    }
}