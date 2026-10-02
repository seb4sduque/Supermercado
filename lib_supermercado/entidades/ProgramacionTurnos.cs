using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_supermercado.entidades
{
    public class ProgramacionTurnos
    {
        public int Id { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public int HorasExtras { get; set; }
        public int Empleado { get; set; }
        public int Turno { get; set; }

        [ForeignKey("Empleado")]
        public Empleados _Empleado { get; set; }

        [ForeignKey("Turno")]
        public Turnos _Turno { get; set; }
    }
}
