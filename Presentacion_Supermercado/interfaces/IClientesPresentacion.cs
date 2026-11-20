using lib_supermercado.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentacion_Supermercado.interfaces
{
    public interface IClientesPresentacion
    {
        Clientes Insertar(Clientes entidad);
        List<Clientes> Consultar();
        Clientes Actualizar(Clientes entidad);
        Clientes Borrar(Clientes entidad);
    }
}
