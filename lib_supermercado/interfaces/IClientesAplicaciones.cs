using lib_supermercado.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace lib_supermercado.interfaces
{
    public interface IClientesAplicaciones
    {
        Clientes Insertar(Clientes entidad);
        List<Clientes> Consultar();
        Clientes Actualizar(Clientes entidad);
        Clientes Borrar(Clientes entidad);
    }
}
