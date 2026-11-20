using lib_supermercado.entidades;
using System.Collections.Generic;

namespace Presentacion_Supermercado.interfaces
{
    public interface IMetodosPagoPresentacion
    {
        MetodosPago Insertar(MetodosPago entidad);
        List<MetodosPago> Consultar();
        MetodosPago Actualizar(MetodosPago entidad);
        MetodosPago Borrar(MetodosPago entidad);
    }
}
