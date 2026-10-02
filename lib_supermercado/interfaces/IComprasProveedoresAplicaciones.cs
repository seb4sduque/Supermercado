using lib_supermercado.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace lib_supermercado.interfaces
{
    public interface IComprasProveedoresAplicaciones
    {
        ComprasProveedores Insertar(ComprasProveedores entidad);
        List<ComprasProveedores> Consultar();
        ComprasProveedores Actualizar(ComprasProveedores entidad);
        ComprasProveedores Borrar(ComprasProveedores entidad);
    }
}
