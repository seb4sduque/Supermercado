using System.Collections.Generic;
using System.Linq;
using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_supermercado.implementaciones
{
    public class SubcategoriasLogica : ISubcategoriasAplicaciones
    {
        private  IConexion conexion;

        public SubcategoriasLogica(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Subcategorias Insertar(Subcategorias entidad)
        {
            this.conexion.Subcategorias.Add(entidad);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Subcategorias> Consultar()
        {
            return this.conexion.Subcategorias.ToList();
        }

        public Subcategorias Actualizar(Subcategorias entidad)
        {
            this.conexion.Entry<Subcategorias>(entidad).State = EntityState.Modified;
            this.conexion.SaveChanges();
            return entidad;
        }

        public Subcategorias Borrar(Subcategorias entidad)
        {
            this.conexion.Subcategorias.Remove(entidad);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}