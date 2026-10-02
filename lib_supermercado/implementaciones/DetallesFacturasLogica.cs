using System.Collections.Generic;
using System.Linq;
using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_supermercado.implementaciones
{
    public class DetallesFacturasLogica : IDetallesFacturasAplicaciones
    {
        private  IConexion conexion;

        public DetallesFacturasLogica(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public DetallesFacturas Insertar(DetallesFacturas entidad)
        {
            this.conexion.DetallesFacturas.Add(entidad);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<DetallesFacturas> Consultar()
        {
            return this.conexion.DetallesFacturas.ToList();
        }

        public DetallesFacturas Actualizar(DetallesFacturas entidad)
        {
            this.conexion.Entry<DetallesFacturas>(entidad).State = EntityState.Modified;
            this.conexion.SaveChanges();
            return entidad;
        }

        public DetallesFacturas Borrar(DetallesFacturas entidad)
        {
            this.conexion.DetallesFacturas.Remove(entidad);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}