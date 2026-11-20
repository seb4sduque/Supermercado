using lib_supermercado.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentacion_Supermercado.interfaces
{
    public interface IBodegasPresentacion
    {
        Bodegas Insertar(Bodegas entidad);
        List<Bodegas> Consultar();
        Bodegas Actualizar(Bodegas entidad);
        Bodegas Borrar(Bodegas entidad);
    }
}
