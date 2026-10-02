using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_supermercado.entidades
{
    public class CuentasCobrar
    {
        public int Id { get; set; }
        public decimal SaldoPendiente { get; set; }
        public string EstadoDeuda { get; set; }
        public int Cliente { get; set; }
        public int Factura { get; set; }

        [ForeignKey("Cliente")]
        public Clientes _Cliente { get; set; }
        [ForeignKey("Factura")]
        public Facturas _Factura { get; set; }
    }
}
