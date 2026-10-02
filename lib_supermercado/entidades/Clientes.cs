using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace lib_supermercado.entidades
{
    public class Clientes
    {
        public int Id { get; set; }
        public string Estado { get; set; }
        public int Persona { get; set; }

        [ForeignKey("Persona")]
        public Personas _Persona { get; set; }
        public List<Facturas> Facturas { get; set; }
        public List<CuentasCobrar> CuentasCobrar { get; set; }
    }
}
