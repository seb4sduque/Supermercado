using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_supermercado.entidades
{
    public class Subcategorias
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Impuesto { get; set; }
        public int Categoria { get; set; }

        public List<Productos> Productos { get; set; }
        [ForeignKey("Categoria")]
        public Categorias _Categoria { get; set; }
    }
}
