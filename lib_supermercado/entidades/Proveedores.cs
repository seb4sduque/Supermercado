using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_supermercado.entidades
{
    public class Proveedores
    {
        public int Id { get; set; }
        public string Direccion { get; set; }
        public string NombreEmpresa { get; set; }
        public string TipoProveedor { get; set; }
        public int Persona { get; set; }

        [ForeignKey("Persona")]
        public Personas _Persona { get; set; }

        public List<ComprasProveedores> ComprasProveedores { get; set; }
    }
}
