using System.Collections.Generic;
using lib_supermercado.entidades;

namespace lib_supermercado.interfaces
{
    public interface IProveedoresAplicaciones
    {
        Proveedores Insertar(Proveedores entidad);
        List<Proveedores> Consultar();
        Proveedores Actualizar(Proveedores entidad);
        Proveedores Borrar(Proveedores entidad);
    }
}
