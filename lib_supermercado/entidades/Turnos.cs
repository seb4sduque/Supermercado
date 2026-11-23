using System;
using System.Collections.Generic;
using System.Text;

namespace lib_supermercado.entidades
{
    public class Turnos : EntidadAuditable
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public TimeSpan HoraInicio { get; set; }
        public TimeSpan HoraFin { get; set; }
        public bool Festivos { get; set; }

        public List<ProgramacionTurnos> ProgramacionTurnos { get; set; }
    }
}
