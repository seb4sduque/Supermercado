using lib_supermercado.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace lib_supermercado.interfaces
{
    public interface ICategoriasAplicaciones
    {
        Categorias Insertar(Categorias entidad);
        List<Categorias> Consultar();
        Categorias Actualizar(Categorias entidad);
        Categorias Borrar(Categorias entidad);
    }
}
