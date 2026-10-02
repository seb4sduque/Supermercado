using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_supermercado.entidades
{
    public class ComprasProveedores
    {
        public int Id { get; set; }
        public int NumeroFactura { get; set; }
        public DateTime FechaCompra { get; set; }
        public decimal TotalCompra { get; set; }
        public int Proveedor { get; set; }

        [ForeignKey("Proveedor")]
        public Proveedores _Proveedor { get; set; }
        public List<DetallesCompras> DetallesCompras { get; set; }
    }
}
