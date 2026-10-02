using System.Collections.Generic;
using System.Linq;
using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_supermercado.implementaciones
{
    public class EmpleadosLogica : IEmpleadosAplicaciones
    {
        private  IConexion conexion;

        public EmpleadosLogica(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Empleados Insertar(Empleados entidad)
        {
            this.conexion.Empleados.Add(entidad);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Empleados> Consultar()
        {
            return this.conexion.Empleados.ToList();
        }

        public Empleados Actualizar(Empleados entidad)
        {
            this.conexion.Entry<Empleados>(entidad).State = EntityState.Modified;
            this.conexion.SaveChanges();
            return entidad;
        }

        public Empleados Borrar(Empleados entidad)
        {
            this.conexion.Empleados.Remove(entidad);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}