using System.Collections.Generic;
using System.Linq;
using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_supermercado.implementaciones
{
    public class InventariosLogica : IInventariosAplicaciones
    {
        private  IConexion conexion;

        public InventariosLogica(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Inventarios Insertar(Inventarios entidad)
        {
            this.conexion.Inventarios.Add(entidad);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Inventarios> Consultar()
        {
            return this.conexion.Inventarios.ToList();
        }

        public Inventarios Actualizar(Inventarios entidad)
        {
            this.conexion.Entry<Inventarios>(entidad).State = EntityState.Modified;
            this.conexion.SaveChanges();
            return entidad;
        }

        public Inventarios Borrar(Inventarios entidad)
        {
            this.conexion.Inventarios.Remove(entidad);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}