using lib_supermercado.entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Presentacion_Supermercado.interfaces
{
    public interface IEmpleadosPresentacion
    {
        Empleados Insertar(Empleados entidad);
        List<Empleados> Consultar();
        Empleados Actualizar(Empleados entidad);
        Empleados Borrar(Empleados entidad);
    }
}
