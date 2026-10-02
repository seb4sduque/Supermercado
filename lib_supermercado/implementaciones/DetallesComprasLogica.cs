using System.Collections.Generic;
using System.Linq;
using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_supermercado.implementaciones
{
    public class DetallesComprasLogica : IDetallesComprasAplicaciones
    {
        private  IConexion conexion;

        public DetallesComprasLogica(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public DetallesCompras Insertar(DetallesCompras entidad)
        {
            this.conexion.DetallesCompras.Add(entidad);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<DetallesCompras> Consultar()
        {
            return this.conexion.DetallesCompras.ToList();
        }

        public DetallesCompras Actualizar(DetallesCompras entidad)
        {
            this.conexion.Entry<DetallesCompras>(entidad).State = EntityState.Modified;
            this.conexion.SaveChanges();
            return entidad;
        }

        public DetallesCompras Borrar(DetallesCompras entidad)
        {
            this.conexion.DetallesCompras.Remove(entidad);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}