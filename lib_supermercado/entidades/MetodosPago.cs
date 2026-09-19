using System;
using System.Collections.Generic;
using System.Text;

namespace lib_supermercado.entidades
{
    public class MetodosPago
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public bool RequiereBanco { get; set; }
        public decimal MontoMinimo { get; set; }

        public List<Facturas> Facturas { get; set; }
    }
}
