using System.Collections.Generic;
using System.Linq;
using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_supermercado.implementaciones
{
    public class ComprasProveedoresLogica : IComprasProveedoresAplicaciones
    {
        private  IConexion conexion;

        public ComprasProveedoresLogica(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public ComprasProveedores Insertar(ComprasProveedores entidad)
        {
            this.conexion.ComprasProveedores.Add(entidad);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<ComprasProveedores> Consultar()
        {
            return this.conexion.ComprasProveedores.ToList();
        }

        public ComprasProveedores Actualizar(ComprasProveedores entidad)
        {
            this.conexion.Entry<ComprasProveedores>(entidad).State = EntityState.Modified;
            this.conexion.SaveChanges();
            return entidad;
        }

        public ComprasProveedores Borrar(ComprasProveedores entidad)
        {
            this.conexion.ComprasProveedores.Remove(entidad);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}