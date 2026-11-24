using System.Collections.Generic;
using System.Linq;
using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_supermercado.implementaciones
{
    public class ProgramacionTurnosLogica : IProgramacionTurnosAplicaciones
    {
        private  IConexion conexion;

        public ProgramacionTurnosLogica(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public ProgramacionTurnos Insertar(ProgramacionTurnos entidad)
        {
            if (entidad.FechaAsignacion.Year < 1753)
                throw new Exception("Debe indicar una fecha de asignación válida");

            if (entidad.HorasExtras < 0)
                throw new Exception("Las horas extras no pueden ser negativas");

            this.conexion.ProgramacionTurnos.Add(entidad);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<ProgramacionTurnos> Consultar()
        {
            return this.conexion.ProgramacionTurnos.ToList();
        }

        public ProgramacionTurnos Actualizar(ProgramacionTurnos entidad)
        {
            if (entidad.FechaAsignacion.Year < 1753)
                throw new Exception("Debe indicar una fecha de asignación válida");

            if (entidad.HorasExtras < 0)
                throw new Exception("Las horas extras no pueden ser negativas");

            this.conexion.Entry<ProgramacionTurnos>(entidad).State = EntityState.Modified;
            this.conexion.SaveChanges();
            return entidad;
        }

        public ProgramacionTurnos Borrar(ProgramacionTurnos entidad)
        {
            this.conexion.ProgramacionTurnos.Remove(entidad);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}