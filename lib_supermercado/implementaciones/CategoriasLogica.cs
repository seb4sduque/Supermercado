using System.Collections.Generic;
using System.Linq;
using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_supermercado.implementaciones
{
    public class CategoriasLogica : ICategoriasAplicaciones
    {
        private  IConexion conexion;

        public CategoriasLogica(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Categorias Insertar(Categorias entidad)
        {
            this.conexion.Categorias.Add(entidad);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Categorias> Consultar()
        {
            return this.conexion.Categorias.ToList();
        }

        public Categorias Actualizar(Categorias entidad)
        {
            this.conexion.Entry<Categorias>(entidad).State = EntityState.Modified;
            this.conexion.SaveChanges();
            return entidad;
        }

        public Categorias Borrar(Categorias entidad)
        {
            this.conexion.Categorias.Remove(entidad);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}