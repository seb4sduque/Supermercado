using System;
using System.Collections.Generic;
using System.Text;

namespace lib_supermercado.entidades
{
    public class Categorias : EntidadAuditable
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string? Descripcion { get; set; }
        public string Estado { get; set; }

        public List<Subcategorias> Subcategorias { get; set; }
    }
}
