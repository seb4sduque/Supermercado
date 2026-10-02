using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_supermercado.entidades
{
    public class Inventarios
    {
        public int Id { get; set; }
        public int Stock { get; set; }
        public int StockMinimo { get; set; }
        public int Producto { get; set; }
        public int Bodega { get; set; }

        [ForeignKey("Producto")]
        public Productos _Producto { get; set; }
        [ForeignKey("Bodega")]
        public Bodegas _Bodega { get; set; }
        public List<MovimientosInventarios> MovimientosInventarios { get; set; }
    }
}
