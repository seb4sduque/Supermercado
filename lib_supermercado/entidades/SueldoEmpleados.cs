using System;
using System.Collections.Generic;
using System.Text;

namespace lib_supermercado.entidades
{
    public class SueldoEmpleados
    {
        public int Id { get; set; }
        public decimal MontoPagado { get; set; }
        public DateTime FechaPago { get; set; }
        public string MetodoPago { get; set; }
        public int EmpleadoId { get; set; }

        public Empleados _empleado { get; set; }
    }
}
