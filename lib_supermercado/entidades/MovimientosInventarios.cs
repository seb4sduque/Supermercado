using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_supermercado.entidades
{
    public class MovimientosInventarios
    {
        public int Id { get; set; }
        public string TipoMovimiento { get; set; }
        public int CantidadMovimiento { get; set; }
        public DateTime FechaHora { get; set; }
        public int Inventario { get; set; }

        [ForeignKey("Inventario")]
        public Inventarios _Inventario { get; set; }
    }
}
