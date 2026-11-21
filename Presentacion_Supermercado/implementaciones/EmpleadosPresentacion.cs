using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.EntityFrameworkCore;
using Presentacion_Supermercado.interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Presentacion_Supermercado.implementaciones
{
    public class EmpleadosPresentacion : IEmpleadosPresentacion
    {
        private IComunicaciones Icomunicaciones;

        public EmpleadosPresentacion(IComunicaciones Icomunicacion)
        {
            this.Icomunicaciones = Icomunicacion;
        }

        public Empleados Insertar(Empleados entidad)
        {
            var task = this.Icomunicaciones.Ejecutar<Empleados>(
                "Empleados/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Empleados> Consultar()
        {
            var task = this.Icomunicaciones.Ejecutar<List<Empleados>>(
                "Empleados/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Empleados Actualizar(Empleados entidad)
        {
            var task = this.Icomunicaciones.Ejecutar<Empleados>(
                "Empleados/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Empleados Borrar(Empleados entidad)
        {
            var task = this.Icomunicaciones.Ejecutar<Empleados>(
                "Empleados/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }
    }
}