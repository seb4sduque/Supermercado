using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_supermercado.entidades
{
    public class Productos
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public string CodigoBarras { get; set; }
        public int Subcategoria { get; set; }

        [ForeignKey("Subcategoria")]
        public Subcategorias _Subcategoria { get; set; }
        public List<Inventarios> Inventarios { get; set; }
        public List<DetallesFacturas> DetallesFacturas { get; set; }
    }
}
