using lib_supermercado.entidades;
using System.Collections.Generic;

namespace Presentacion_Supermercado.interfaces
{
    public interface IProgramacionTurnosPresentacion
    {
        ProgramacionTurnos Insertar(ProgramacionTurnos entidad);
        List<ProgramacionTurnos> Consultar();
        ProgramacionTurnos Actualizar(ProgramacionTurnos entidad);
        ProgramacionTurnos Borrar(ProgramacionTurnos entidad);
    }
}
