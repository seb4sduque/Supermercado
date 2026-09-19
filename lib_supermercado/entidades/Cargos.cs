using System;
using System.Collections.Generic;
using System.Text;

namespace lib_supermercado.entidades
{
    public class Cargos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal SalarioBase { get; set; }
        public string NivelAcceso { get; set; }

        public List<Empleados> Empleados { get; set; }
    }
}
