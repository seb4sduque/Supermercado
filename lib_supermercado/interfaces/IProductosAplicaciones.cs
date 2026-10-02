using System.Collections.Generic;
using lib_supermercado.entidades;

namespace lib_supermercado.interfaces
{
    public interface IProductosAplicaciones
    {
        Productos Insertar(Productos entidad);
        List<Productos> Consultar();
        Productos Actualizar(Productos entidad);
        Productos Borrar(Productos entidad);
    }
}
