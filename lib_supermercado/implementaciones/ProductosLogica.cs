using System.Collections.Generic;
using System.Linq;
using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_supermercado.implementaciones
{
    public class ProductosLogica : IProductosAplicaciones
    {
        private  IConexion conexion;

        public ProductosLogica(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Productos Insertar(Productos entidad)
        {
            this.conexion.Productos.Add(entidad);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Productos> Consultar()
        {
            return this.conexion.Productos.ToList();
        }

        public Productos Actualizar(Productos entidad)
        {
            this.conexion.Entry<Productos>(entidad).State = EntityState.Modified;
            this.conexion.SaveChanges();
            return entidad;
        }

        public Productos Borrar(Productos entidad)
        {
            this.conexion.Productos.Remove(entidad);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}