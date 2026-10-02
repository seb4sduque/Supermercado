using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_supermercado.entidades
{
    public class Empleados
    {
        public int Id { get; set; }
        public DateTime FechaContratacion { get; set; }
        public int Persona { get; set; }
        public int Cargo { get; set; }

        [ForeignKey("Persona")]
        public Personas _Persona { get; set; }
        [ForeignKey("Cargo")]
        public Cargos _Cargo { get; set; }
        public List<Facturas> Facturas { get; set; }
        public List<SueldoEmpleados> SueldosEmpleados { get; set; }
    }
}
