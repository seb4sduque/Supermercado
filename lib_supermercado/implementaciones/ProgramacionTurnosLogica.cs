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