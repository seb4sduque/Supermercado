using lib_supermercado.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace lib_supermercado.interfaces
{
    public interface IDetallesComprasAplicaciones
    {
        DetallesCompras Insertar(DetallesCompras entidad);
        List<DetallesCompras> Consultar();
        DetallesCompras Actualizar(DetallesCompras entidad);
        DetallesCompras Borrar(DetallesCompras entidad);
    }
}
