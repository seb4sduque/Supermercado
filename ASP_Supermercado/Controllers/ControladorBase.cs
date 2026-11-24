using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Text.RegularExpressions;

namespace ASP_Supermercado.Controllers
{
    // Base de todos los controladores: cada acción atrapa sus errores con try/catch y responde
    // con un mensaje claro, para que la excepción no salga del código (y Visual Studio no se detenga)
    public abstract class ControladorBase : ControllerBase
    {
        protected ObjectResult Error(Exception ex)
        {
            var mensaje = MensajeDeError(ex);
            return StatusCode(mensaje.Item1, mensaje.Item2);
        }

        // Traduce el error técnico a una advertencia que el usuario pueda entender
        public static (int, string) MensajeDeError(Exception ex)
        {
            // Errores de reglas de negocio que lanza la lógica con throw new Exception("...")
            if (ex.GetType() == typeof(Exception))
                return (400, ex.Message);

            var sql = ex.GetBaseException() as SqlException;
            if (sql == null)
                return (500, "Ocurrió un error en el servidor. Intente de nuevo.");

            var texto = sql.Message;
            var restriccion = Regex.Match(texto, "\"(FK_[A-Za-z0-9]+_[A-Za-z0-9]+)\"");
            var columna = Regex.Match(texto, "'([A-Za-z0-9]+)'");

            switch (sql.Number)
            {
                case 547 when restriccion.Success:
                    var partes = restriccion.Groups[1].Value.Split('_'); // FK_Hijo_Padre
                    var hijo = Regex.Replace(partes[1], "(?<=[a-z])(?=[A-Z])", " ");
                    var padre = Regex.Replace(partes[2], "(?<=[a-z])(?=[A-Z])", " ");
                    if (texto.Contains("DELETE"))
                        return (400, $"No se puede borrar este registro porque está siendo usado en {hijo}. " +
                                     $"Primero borre o cambie esos registros de {hijo}.");
                    return (400, $"Debe seleccionar un valor válido en {padre}.");
                case 515:
                    return (400, columna.Success
                        ? $"Falta completar el campo {columna.Groups[1].Value}."
                        : "Faltan datos obligatorios. Complete todos los campos.");
                case 242:
                    return (400, "Debe indicar una fecha válida (entre 1753 y 9999).");
                case 2601:
                case 2627:
                    return (400, "Ya existe un registro con ese valor.");
                case 8152:
                case 2628:
                    return (400, "Hay un texto demasiado largo. Reduzca su tamaño.");
                case -1:
                case 2:
                case 53:
                    return (500, "No se pudo conectar con la base de datos. Verifique que SQL Server esté iniciado.");
                default:
                    return (400, "No se pudo completar la operación en la base de datos.");
            }
        }
    }
}
