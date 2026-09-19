using System;
using System.Collections.Generic;
using System.Text;

namespace lib_supermercado.entidades
{
    public class Personas
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public string Documento { get; set; }

        public List<Clientes> Clientes { get; set; }
        public List<Proveedores> Proveedores { get; set; }
        public List<Empleados> Empleados { get; set; }
    }
}
