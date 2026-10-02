using System.Collections.Generic;
using lib_supermercado.entidades;

namespace lib_supermercado.interfaces
{
    public interface ISueldoEmpleadosAplicaciones
    {
        SueldoEmpleados Insertar(SueldoEmpleados entidad);
        List<SueldoEmpleados> Consultar();
        SueldoEmpleados Actualizar(SueldoEmpleados entidad);
        SueldoEmpleados Borrar(SueldoEmpleados entidad);
    }
}
