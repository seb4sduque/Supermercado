using System.Collections.Generic;
using lib_supermercado.entidades;

namespace lib_supermercado.interfaces
{
    public interface IProgramacionTurnosAplicaciones
    {
        ProgramacionTurnos Insertar(ProgramacionTurnos entidad);
        List<ProgramacionTurnos> Consultar();
        ProgramacionTurnos Actualizar(ProgramacionTurnos entidad);
        ProgramacionTurnos Borrar(ProgramacionTurnos entidad);
    }
}
