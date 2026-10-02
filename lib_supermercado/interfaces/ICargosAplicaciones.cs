using lib_supermercado.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace lib_supermercado.interfaces
{
    public interface ICargosAplicaciones
    {
        Cargos Insertar(Cargos entidad);
        List<Cargos> Consultar();
        Cargos Actualizar(Cargos entidad);
        Cargos Borrar(Cargos entidad);
    }
}
