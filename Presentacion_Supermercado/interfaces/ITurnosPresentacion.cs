using System.Collections.Generic;
using lib_supermercado.entidades;

namespace Presentacion_Supermercado.interfaces
{
    public interface ITurnosPresentacion
    {
        Turnos Insertar(Turnos entidad);
        List<Turnos> Consultar();
        Turnos Actualizar(Turnos entidad);
        Turnos Borrar(Turnos entidad);
    }
}
