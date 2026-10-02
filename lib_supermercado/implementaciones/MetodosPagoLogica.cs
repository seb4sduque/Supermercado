using System.Collections.Generic;
using System.Linq;
using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_supermercado.implementaciones
{
    public class MetodosPagoLogica : IMetodosPagoAplicaciones
    {
        private  IConexion conexion;

        public MetodosPagoLogica(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public MetodosPago Insertar(MetodosPago entidad)
        {
            this.conexion.MetodosPago.Add(entidad);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<MetodosPago> Consultar()
        {
            return this.conexion.MetodosPago.ToList();
        }

        public MetodosPago Actualizar(MetodosPago entidad)
        {
            this.conexion.Entry<MetodosPago>(entidad).State = EntityState.Modified;
            this.conexion.SaveChanges();
            return entidad;
        }

        public MetodosPago Borrar(MetodosPago entidad)
        {
            this.conexion.MetodosPago.Remove(entidad);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}