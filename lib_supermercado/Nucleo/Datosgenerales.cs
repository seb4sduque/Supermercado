using System;
using System.Collections.Generic;
using System.Text;

namespace lib_supermercado.Nucleo
{
    public class Datosgenerales
    {
        public static string ObtenerStringConexion()
        {
            return "server=localhost;database=SupermercadoDB;Integrated Security=True;TrustServerCertificate=true;";
        }
    }
}

