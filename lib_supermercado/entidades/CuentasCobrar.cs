using System;
using System.Collections.Generic;
using System.Text;

namespace lib_supermercado.entidades
{
    public class CuentasCobrar
    {
        public int Id { get; set; }
        public decimal SaldoPendiente { get; set; }
        public string EstadoDeuda { get; set; }
        public int ClienteId { get; set; }
        public int FacturaId { get; set; }

        public Clientes _cliente { get; set; }
        public Facturas _factura { get; set; }
    }
}
