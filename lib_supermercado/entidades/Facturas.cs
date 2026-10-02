using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_supermercado.entidades
{
    public class Facturas
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public decimal TotalPagar { get; set; }
        public string Estado { get; set; }
        public int Cliente { get; set; }
        public int Empleado { get; set; }
        public int MetodoPago { get; set; }

        [ForeignKey("Cliente")]
        public Clientes _Cliente { get; set; }

        [ForeignKey("Empleado")]
        public Empleados _Empleado { get; set; }

        [ForeignKey("MetodoPago")]
        public MetodosPago _MetodoPago { get; set; }
        public List<DetallesFacturas> DetallesFacturas { get; set; }
        public List<CuentasCobrar> CuentasCobrar { get; set; }
    }
}
