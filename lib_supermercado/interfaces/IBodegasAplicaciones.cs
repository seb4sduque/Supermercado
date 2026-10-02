using lib_supermercado.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace lib_supermercado.interfaces
{
    public interface IBodegasAplicaciones
    {
        Bodegas Insertar(Bodegas entidad);
        List<Bodegas> Consultar();
        Bodegas Actualizar(Bodegas entidad);
        Bodegas Borrar(Bodegas entidad);
    }
}
