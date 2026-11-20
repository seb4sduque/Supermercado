using lib_supermercado.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentacion_Supermercado.interfaces
{
    public interface ICuentasCobrarPresentacion
    {
        CuentasCobrar Insertar(CuentasCobrar entidad);
        List<CuentasCobrar> Consultar();
        CuentasCobrar Actualizar(CuentasCobrar entidad);
        CuentasCobrar Borrar(CuentasCobrar entidad);
    }
}
