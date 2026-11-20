using lib_supermercado.entidades;
using System.Collections.Generic;

namespace Presentacion_Supermercado.interfaces
{
    public interface ISubcategoriasPresentacion
    {
        Subcategorias Insertar(Subcategorias entidad);
        List<Subcategorias> Consultar();
        Subcategorias Actualizar(Subcategorias entidad);
        Subcategorias Borrar(Subcategorias entidad);
    }
}
