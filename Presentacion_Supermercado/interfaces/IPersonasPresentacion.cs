using lib_supermercado.entidades;
using System.Collections.Generic;

namespace Presentacion_Supermercado.interfaces
{
    public interface IPersonasPresentacion
    {
        Personas Insertar(Personas entidad);
        List<Personas> Consultar();
        Personas Actualizar(Personas entidad);
        Personas Borrar(Personas entidad);
    }
}
