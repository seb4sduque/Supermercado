using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.EntityFrameworkCore;
using Presentacion_Supermercado.interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Presentacion_Supermercado.implementaciones
{
    public class ProgramacionTurnosPresentacion : IProgramacionTurnosPresentacion
    {
        private IComunicaciones Icomunicaciones;

        public ProgramacionTurnosPresentacion(IComunicaciones Icomunicacion)
        {
            this.Icomunicaciones = Icomunicacion;
        }

        public ProgramacionTurnos Insertar(ProgramacionTurnos entidad)
        {
            var task = this.Icomunicaciones.Ejecutar<ProgramacionTurnos>(
                 "ProgramacionTurnos/Insertar",
                 entidad);
            task.Wait();
            return task.Result;
        }

        public List<ProgramacionTurnos> Consultar()
        {
            var task = this.Icomunicaciones.Ejecutar<List<ProgramacionTurnos>>(
                "ProgramacionTurnos/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public ProgramacionTurnos Actualizar(ProgramacionTurnos entidad)
        {
            var task = this.Icomunicaciones.Ejecutar<ProgramacionTurnos>(
                "ProgramacionTurnos/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public ProgramacionTurnos Borrar(ProgramacionTurnos entidad)
        {
            var task = this.Icomunicaciones.Ejecutar<ProgramacionTurnos>(
                "ProgramacionTurnos/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }
    }
}