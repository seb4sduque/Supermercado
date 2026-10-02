using System.Collections.Generic;
using lib_supermercado.entidades;

namespace lib_supermercado.interfaces
{
    public interface ITurnosAplicaciones
    {
        Turnos Insertar(Turnos entidad);
        List<Turnos> Consultar();
        Turnos Actualizar(Turnos entidad);
        Turnos Borrar(Turnos entidad);
    }
}
