using lib_supermercado.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentacion_Supermercado.interfaces
{
    public interface ICategoriasPresentacion
    {
        Categorias Insertar(Categorias entidad);
        List<Categorias> Consultar();
        Categorias Actualizar(Categorias entidad);
        Categorias Borrar(Categorias entidad);
    }
}
