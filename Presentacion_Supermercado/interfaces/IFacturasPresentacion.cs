using lib_supermercado.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentacion_Supermercado.interfaces
{
    public interface IFacturasPresentacion
    {
        Facturas Insertar(Facturas entidad);
        List<Facturas> Consultar();
        Facturas Actualizar(Facturas entidad);
        Facturas Borrar(Facturas entidad);
    }
}
