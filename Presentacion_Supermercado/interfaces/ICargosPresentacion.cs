using lib_supermercado.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentacion_Supermercado.interfaces
{
    public interface ICargosPresentacion
    {
        Cargos Insertar(Cargos entidad);
        List<Cargos> Consultar();
        Cargos Actualizar(Cargos entidad);
        Cargos Borrar(Cargos entidad);
    }
}
