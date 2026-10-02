using System.Collections.Generic;
using System.Linq;
using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_supermercado.implementaciones
{
    public class MovimientosInventariosLogica : IMovimientosInventariosAplicaciones
    {
        private  IConexion conexion;

        public MovimientosInventariosLogica(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public MovimientosInventarios Insertar(MovimientosInventarios entidad)
        {
            this.conexion.MovimientosInventarios.Add(entidad);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<MovimientosInventarios> Consultar()
        {
            return this.conexion.MovimientosInventarios.ToList();
        }

        public MovimientosInventarios Actualizar(MovimientosInventarios entidad)
        {
            this.conexion.Entry<MovimientosInventarios>(entidad).State = EntityState.Modified;
            this.conexion.SaveChanges();
            return entidad;
        }

        public MovimientosInventarios Borrar(MovimientosInventarios entidad)
        {
            this.conexion.MovimientosInventarios.Remove(entidad);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}