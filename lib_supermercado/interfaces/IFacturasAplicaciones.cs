using lib_supermercado.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace lib_supermercado.interfaces
{
    public interface IFacturasAplicaciones
    {
        Facturas Insertar(Facturas entidad);
        List<Facturas> Consultar();
        Facturas Actualizar(Facturas entidad);
        Facturas Borrar(Facturas entidad);
    }
}
