using System.Collections.Generic;
using System.Linq;
using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_supermercado.implementaciones
{
    public class SueldoEmpleadosLogica : ISueldoEmpleadosAplicaciones
    {
        private  IConexion conexion;

        public SueldoEmpleadosLogica(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public SueldoEmpleados Insertar(SueldoEmpleados entidad)
        {
            this.conexion.SueldoEmpleados.Add(entidad);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<SueldoEmpleados> Consultar()
        {
            return this.conexion.SueldoEmpleados.ToList();
        }

        public SueldoEmpleados Actualizar(SueldoEmpleados entidad)
        {
            this.conexion.Entry<SueldoEmpleados>(entidad).State = EntityState.Modified;
            this.conexion.SaveChanges();
            return entidad;
        }

        public SueldoEmpleados Borrar(SueldoEmpleados entidad)
        {
            this.conexion.SueldoEmpleados.Remove(entidad);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}