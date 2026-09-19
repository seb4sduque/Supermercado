using System;
using System.Collections.Generic;
using System.Text;

namespace lib_supermercado.entidades
{

    public class Bodegas
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Capacidad { get; set; }
        public string Estado { get; set; }

        public List<Inventarios> Inventarios { get; set; }
    }
}
