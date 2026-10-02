using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_supermercado.entidades
{
    public class DetallesCompras
    {
        public int Id { get; set; }
        public decimal PrecioCompra { get; set; }
        public int Cantidad { get; set; }
        public int Producto { get; set; }
        public int CompraProveedor { get; set; }

        [ForeignKey("Producto")]
        public Productos _Producto { get; set; }
        [ForeignKey("CompraProveedor")]
        public ComprasProveedores _CompraProveedor { get; set; }
    }
}
