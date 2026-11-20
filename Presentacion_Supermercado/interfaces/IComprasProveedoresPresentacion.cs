using lib_supermercado.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentacion_Supermercado.interfaces
{
    public interface IComprasProveedoresPresentacion
    {
        ComprasProveedores Insertar(ComprasProveedores entidad);
        List<ComprasProveedores> Consultar();
        ComprasProveedores Actualizar(ComprasProveedores entidad);
        ComprasProveedores Borrar(ComprasProveedores entidad);
    }
}
