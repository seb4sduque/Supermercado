using lib_supermercado.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace lib_supermercado.interfaces
{
    public interface IInventariosAplicaciones
    {
        Inventarios Insertar(Inventarios entidad);
        List<Inventarios> Consultar();
        Inventarios Actualizar(Inventarios entidad);
        Inventarios Borrar(Inventarios entidad);
    }
}
