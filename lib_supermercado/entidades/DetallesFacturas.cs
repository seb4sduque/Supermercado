using System;
using System.Collections.Generic;
using System.Text;

namespace lib_supermercado.entidades
{
    public class DetallesFacturas
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public int FacturaId { get; set; }
        public int ProductoId { get; set; }

        public Facturas _factura { get; set; }
        public Productos _producto { get; set; }
    }
}
