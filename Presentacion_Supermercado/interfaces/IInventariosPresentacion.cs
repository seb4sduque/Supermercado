using lib_supermercado.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentacion_Supermercado.interfaces
{
    public interface IInventariosPresentacion
    {
        Inventarios Insertar(Inventarios entidad);
        List<Inventarios> Consultar();
        Inventarios Actualizar(Inventarios entidad);
        Inventarios Borrar(Inventarios entidad);
    }
}
