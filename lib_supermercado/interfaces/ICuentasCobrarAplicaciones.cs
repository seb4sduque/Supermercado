using lib_supermercado.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace lib_supermercado.interfaces
{
    public interface ICuentasCobrarAplicaciones
    {
        CuentasCobrar Insertar(CuentasCobrar entidad);
        List<CuentasCobrar> Consultar();
        CuentasCobrar Actualizar(CuentasCobrar entidad);
        CuentasCobrar Borrar(CuentasCobrar entidad);
    }
}
