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
            if (this.conexion.Productos.Any(x => x.CodigoBarras == entidad.CodigoBarras))
                throw new Exception("El código de barras ya existe");

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
            if (this.conexion.Productos.Any(x => x.CodigoBarras == entidad.CodigoBarras && x.Id != entidad.Id))
                throw new Exception("El código de barras ya está en uso");

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