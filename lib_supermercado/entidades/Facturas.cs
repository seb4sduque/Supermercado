using System;
using System.Collections.Generic;
using System.Text;

namespace lib_supermercado.entidades
{
    public class Facturas
    {
        public int Id { get; set; }
        public DateTime FechaHora { get; set; }
        public decimal TotalPagar { get; set; }
        public string Estado { get; set; }
        public int ClienteId { get; set; }
        public int EmpleadoId { get; set; }
        public int MetodoPagoId { get; set; }

        public Clientes _cliente { get; set; }
        public Empleados _empleado { get; set; }
        public MetodosPago _metodoPago { get; set; }
        public List<DetallesFacturas> DetallesFacturas { get; set; }
        public List<CuentasCobrar> CuentasCobrar { get; set; }
    }
}
