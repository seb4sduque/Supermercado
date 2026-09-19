using System;
using System.Collections.Generic;
using System.Text;

namespace lib_supermercado.entidades
{
    public class Proveedores
    {
        public int Id { get; set; }
        public string Direccion { get; set; }
        public string NombreEmpresa { get; set; }
        public string TipoProveedor { get; set; }
        public int PersonaId { get; set; }

        public Personas _persona { get; set; }
        public List<ComprasProveedores> ComprasProveedores { get; set; }
    }
}
