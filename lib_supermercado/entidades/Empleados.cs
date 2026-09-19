using System;
using System.Collections.Generic;
using System.Text;

namespace lib_supermercado.entidades
{
    public class Empleados
    {
        public int Id { get; set; }
        public DateTime FechaContratacion { get; set; }
        public int PersonaId { get; set; }
        public int CargoId { get; set; }

        public Personas _persona { get; set; }
        public Cargos _cargo { get; set; }
        public List<Facturas> Facturas { get; set; }
        public List<SueldoEmpleados> SueldosEmpleados { get; set; }
    }
}
