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
            if (this.conexion.Personas.Any(x => x.Documento == entidad.Documento))
                throw new Exception("El documento ya existe");

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
            if (this.conexion.Personas.Any(x => x.Documento == entidad.Documento && x.Id != entidad.Id))
                throw new Exception("El documento ya está en uso");

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