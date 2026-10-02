using System.Collections.Generic;
using lib_supermercado.entidades;

namespace lib_supermercado.interfaces
{
    public interface IMetodosPagoAplicaciones
    {
        MetodosPago Insertar(MetodosPago entidad);
        List<MetodosPago> Consultar();
        MetodosPago Actualizar(MetodosPago entidad);
        MetodosPago Borrar(MetodosPago entidad);
    }
}
