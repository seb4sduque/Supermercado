using System.Collections.Generic;
using System.Linq;
using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_supermercado.implementaciones
{
    public class CargosLogica : ICargosAplicaciones
    {
        private  IConexion conexion;

        public CargosLogica(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Cargos Insertar(Cargos entidad)
        {
            this.conexion.Cargos.Add(entidad);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Cargos> Consultar()
        {
            return this.conexion.Cargos.ToList();
        }

        public Cargos Actualizar(Cargos entidad)
        {
            this.conexion.Entry<Cargos>(entidad).State = EntityState.Modified;
            this.conexion.SaveChanges();
            return entidad;
        }

        public Cargos Borrar(Cargos entidad)
        {
            this.conexion.Cargos.Remove(entidad);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}