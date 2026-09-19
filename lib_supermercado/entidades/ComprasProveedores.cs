using System;
using System.Collections.Generic;
using System.Text;

namespace lib_supermercado.entidades
{
    public class ComprasProveedores
    {
        public int Id { get; set; }
        public int NumeroFactura { get; set; }
        public DateTime FechaCompra { get; set; }
        public decimal TotalCompra { get; set; }
        public int ProveedorId { get; set; }

        public Proveedores _proveedor { get; set; }
        public List<DetallesCompras> DetallesCompras { get; set; }
    }
}
