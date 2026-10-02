using System.Collections.Generic;
using System.Linq;
using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_supermercado.implementaciones
{
    public class TurnosLogica : ITurnosAplicaciones
    {
        private  IConexion conexion;

        public TurnosLogica(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Turnos Insertar(Turnos entidad)
        {
            this.conexion.Turnos.Add(entidad);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Turnos> Consultar()
        {
            return this.conexion.Turnos.ToList();
        }

        public Turnos Actualizar(Turnos entidad)
        {
            this.conexion.Entry<Turnos>(entidad).State = EntityState.Modified;
            this.conexion.SaveChanges();
            return entidad;
        }

        public Turnos Borrar(Turnos entidad)
        {
            this.conexion.Turnos.Remove(entidad);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}