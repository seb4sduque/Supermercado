using System;
using System.Collections.Generic;
using System.Text;

namespace lib_supermercado.entidades
{
    public class DetallesCompras
    {
        public int Id { get; set; }
        public decimal PrecioCompra { get; set; }
        public int Cantidad { get; set; }
        public int ProductoId { get; set; }
        public int CompraProveedorId { get; set; }

        public Productos _producto { get; set; }
        public ComprasProveedores _compraProveedor { get; set; }
    }
}
