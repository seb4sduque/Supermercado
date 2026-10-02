using System.Collections.Generic;
using System.Linq;
using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_supermercado.implementaciones
{
    public class PersonasLogica : IPersonasAplicaciones
    {
        private  IConexion conexion;

        public PersonasLogica(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Personas Insertar(Personas entidad)
        {
            this.conexion.Personas.Add(entidad);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Personas> Consultar()
        {
            return this.conexion.Personas.ToList();
        }

        public Personas Actualizar(Personas entidad)
        {
            this.conexion.Entry<Personas>(entidad).State = EntityState.Modified;
            this.conexion.SaveChanges();
            return entidad;
        }

        public Personas Borrar(Personas entidad)
        {
            this.conexion.Personas.Remove(entidad);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}