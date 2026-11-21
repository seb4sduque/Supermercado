using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.EntityFrameworkCore;
using Presentacion_Supermercado.interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Presentacion_Supermercado.implementaciones
{
    public class PersonasPresentacion : IPersonasPresentacion
    {
        private IComunicaciones Icomunicaciones;

        public PersonasPresentacion(IComunicaciones Icomunicacion)
        {
            this.Icomunicaciones = Icomunicacion;
        }
        public Personas Insertar(Personas entidad)
        {
            var task = this.Icomunicaciones.Ejecutar<Personas>(
                "Personas/Insertar",
                entidad);
            task.Wait();
            return task.Result;

        }

        public List<Personas> Consultar()
        {
            var task = this.Icomunicaciones.Ejecutar<List<Personas>>(
                "Personas/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Personas Actualizar(Personas entidad)
        {
            var task = this.Icomunicaciones.Ejecutar<Personas>(
                "Personas/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Personas Borrar(Personas entidad)
        {
            var task = this.Icomunicaciones.Ejecutar<Personas>(
                "Personas/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }
    }
}