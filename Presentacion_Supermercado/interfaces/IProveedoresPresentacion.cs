using lib_supermercado.entidades;
using System.Collections.Generic;

namespace Presentacion_Supermercado.interfaces
{
    public interface IProveedoresPresentacion
    {
        Proveedores Insertar(Proveedores entidad);
        List<Proveedores> Consultar();
        Proveedores Actualizar(Proveedores entidad);
        Proveedores Borrar(Proveedores entidad);
    }
}
