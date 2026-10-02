using System.Collections.Generic;
using System.Linq;
using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_supermercado.implementaciones
{
    public class ProveedoresLogica : IProveedoresAplicaciones
    {
        private IConexion conexion;

        public ProveedoresLogica(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Proveedores Insertar(Proveedores entidad)
        {
            this.conexion.Proveedores.Add(entidad);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Proveedores> Consultar()
        {
            return this.conexion.Proveedores.ToList();
        }

        public Proveedores Actualizar(Proveedores entidad)
        {
            this.conexion.Entry<Proveedores>(entidad).State = EntityState.Modified;
            this.conexion.SaveChanges();
            return entidad;
        }

        public Proveedores Borrar(Proveedores entidad)
        {
            this.conexion.Proveedores.Remove(entidad);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}