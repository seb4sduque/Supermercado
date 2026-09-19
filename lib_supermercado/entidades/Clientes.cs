using System;
using System.Collections.Generic;
using System.Text;

namespace lib_supermercado.entidades
{
    public class Clientes
    {
        public int Id { get; set; }
        public string Estado { get; set; }
        public int PersonaId { get; set; }

        public Personas _persona { get; set; }
        public List<Facturas> Facturas { get; set; }
        public List<CuentasCobrar> CuentasCobrar { get; set; }
    }
}
