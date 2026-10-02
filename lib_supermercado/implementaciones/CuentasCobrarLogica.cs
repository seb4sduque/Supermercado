using System.Collections.Generic;
using System.Linq;
using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_supermercado.implementaciones
{
    public class CuentasCobrarLogica : ICuentasCobrarAplicaciones
    {
        private  IConexion conexion;

        public CuentasCobrarLogica(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public CuentasCobrar Insertar(CuentasCobrar entidad)
        {
            this.conexion.CuentasCobrar.Add(entidad);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<CuentasCobrar> Consultar()
        {
            return this.conexion.CuentasCobrar.ToList();
        }

        public CuentasCobrar Actualizar(CuentasCobrar entidad)
        {
            this.conexion.Entry<CuentasCobrar>(entidad).State = EntityState.Modified;
            this.conexion.SaveChanges();
            return entidad;
        }

        public CuentasCobrar Borrar(CuentasCobrar entidad)
        {
            this.conexion.CuentasCobrar.Remove(entidad);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}