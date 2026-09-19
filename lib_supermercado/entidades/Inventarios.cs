using System;
using System.Collections.Generic;
using System.Text;

namespace lib_supermercado.entidades
{
    public class Inventarios
    {
        public int Id { get; set; }
        public int Stock { get; set; }
        public int StockMinimo { get; set; }
        public int ProductoId { get; set; }
        public int BodegaId { get; set; }

        public Productos _producto { get; set; }
        public Bodegas _bodega { get; set; }
        public List<MovimientosInventarios> MovimientosInventarios { get; set; }
    }
}
