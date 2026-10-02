using System.Collections.Generic;
using System.Linq;
using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_supermercado.implementaciones
{
    public class BodegasLogica : IBodegasAplicaciones
    {
        private  IConexion conexion;

        public BodegasLogica(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Bodegas Insertar(Bodegas entidad)
        {
            this.conexion.Bodegas.Add(entidad);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Bodegas> Consultar()
        {
            return this.conexion.Bodegas.ToList();
        }

        public Bodegas Actualizar(Bodegas entidad)
        {
            this.conexion.Entry<Bodegas>(entidad).State = EntityState.Modified;
            this.conexion.SaveChanges();
            return entidad;
        }

        public Bodegas Borrar(Bodegas entidad)
        {
            this.conexion.Bodegas.Remove(entidad);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}