using System.Collections.Generic;
using System.Linq;
using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_supermercado.implementaciones
{
    public class FacturasLogica : IFacturasAplicaciones
    {
        private  IConexion conexion;

        public FacturasLogica(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Facturas Insertar(Facturas entidad)
        {
            this.conexion.Facturas.Add(entidad);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Facturas> Consultar()
        {
            return this.conexion.Facturas.ToList();
        }

        public Facturas Actualizar(Facturas entidad)
        {
            this.conexion.Entry<Facturas>(entidad).State = EntityState.Modified;
            this.conexion.SaveChanges();
            return entidad;
        }

        public Facturas Borrar(Facturas entidad)
        {
            this.conexion.Facturas.Remove(entidad);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}