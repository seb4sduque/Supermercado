using System;
using System.Collections.Generic;
using System.Text;

namespace lib_supermercado.entidades
{
    public class MovimientosInventarios
    {
        public int Id { get; set; }
        public string TipoMovimiento { get; set; }
        public int CantidadMovimiento { get; set; }
        public DateTime FechaHora { get; set; }
        public int InventarioId { get; set; }

        public Inventarios _inventario { get; set; }
    }
}
