using System;
using System.Collections.Generic;
using System.Text;

namespace lib_supermercado.entidades
{
    public class ProgramacionTurnos
    {
        public int Id { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public int HorasExtras { get; set; }
        public int EmpleadoId { get; set; }
        public int TurnoId { get; set; }

        public Empleados _empleado { get; set; }
        public Turnos _turno { get; set; }
    }
}
