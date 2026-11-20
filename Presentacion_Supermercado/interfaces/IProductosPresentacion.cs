using lib_supermercado.entidades;
using System.Collections.Generic;

namespace Presentacion_Supermercado.interfaces
{
    public interface IProductosPresentacion
    {
        Productos Insertar(Productos entidad);
        List<Productos> Consultar();
        Productos Actualizar(Productos entidad);
        Productos Borrar(Productos entidad);
    }
}
