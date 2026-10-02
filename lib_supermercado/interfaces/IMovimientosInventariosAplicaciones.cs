using System.Collections.Generic;
using lib_supermercado.entidades;

namespace lib_supermercado.interfaces
{
    public interface IMovimientosInventariosAplicaciones
    {
        MovimientosInventarios Insertar(MovimientosInventarios entidad);
        List<MovimientosInventarios> Consultar();
        MovimientosInventarios Actualizar(MovimientosInventarios entidad);
        MovimientosInventarios Borrar(MovimientosInventarios entidad);
    }
}
