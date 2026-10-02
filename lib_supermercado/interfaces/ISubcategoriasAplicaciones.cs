using System.Collections.Generic;
using lib_supermercado.entidades;

namespace lib_supermercado.interfaces
{
    public interface ISubcategoriasAplicaciones
    {
        Subcategorias Insertar(Subcategorias entidad);
        List<Subcategorias> Consultar();
        Subcategorias Actualizar(Subcategorias entidad);
        Subcategorias Borrar(Subcategorias entidad);
    }
}
