using lib_supermercado.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentacion_Supermercado.interfaces
{
    public interface IDetallesComprasPresentacion
    {
        DetallesCompras Insertar(DetallesCompras entidad);
        List<DetallesCompras> Consultar();
        DetallesCompras Actualizar(DetallesCompras entidad);
        DetallesCompras Borrar(DetallesCompras entidad);
    }
}
