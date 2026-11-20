using lib_supermercado.entidades;
using System.Collections.Generic;

namespace Presentacion_Supermercado.interfaces
{
    public interface ISueldoEmpleadosPresentacion
    {
        SueldoEmpleados Insertar(SueldoEmpleados entidad);
        List<SueldoEmpleados> Consultar();
        SueldoEmpleados Actualizar(SueldoEmpleados entidad);
        SueldoEmpleados Borrar(SueldoEmpleados entidad);
    }
}
