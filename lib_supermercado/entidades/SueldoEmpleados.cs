using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_supermercado.entidades
{
    public class SueldoEmpleados
    {
        public int Id { get; set; }
        public decimal MontoPagado { get; set; }
        public DateTime FechaPago { get; set; }
        public string MetodoPago { get; set; }
        public int Empleado { get; set; }

        [ForeignKey("Empleado")]
        public Empleados _Empleado { get; set; }
    }
}
