using lib_supermercado.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace lib_supermercado.interfaces
{
    public interface IEmpleadosAplicaciones
    {
        Empleados Insertar(Empleados entidad);
        List<Empleados> Consultar();
        Empleados Actualizar(Empleados entidad);
        Empleados Borrar(Empleados entidad);
    }
}
