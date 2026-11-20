using lib_supermercado.entidades;
using System.Collections.Generic;

namespace Presentacion_Supermercado.interfaces
{
    public interface IMovimientosInventariosPresentacion
    {
        MovimientosInventarios Insertar(MovimientosInventarios entidad);
        List<MovimientosInventarios> Consultar();
        MovimientosInventarios Actualizar(MovimientosInventarios entidad);
        MovimientosInventarios Borrar(MovimientosInventarios entidad);
    }
}
