using System.Collections.Generic;
using lib_supermercado.entidades;

namespace lib_supermercado.interfaces
{
    public interface IPersonasAplicaciones
    {
        Personas Insertar(Personas entidad);
        List<Personas> Consultar();
        Personas Actualizar(Personas entidad);
        Personas Borrar(Personas entidad);
    }
}
