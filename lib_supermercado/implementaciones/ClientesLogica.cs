using System.Collections.Generic;
using System.Linq;
using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.EntityFrameworkCore;

namespace lib_supermercado.implementaciones
{
    public class ClientesLogica : IClientesAplicaciones
    {
        private  IConexion conexion;

        public ClientesLogica(IConexion conexion)
        {
            this.conexion = conexion;
        }

        public Clientes Insertar(Clientes entidad)
        {
            this.conexion.Clientes.Add(entidad);
            this.conexion.SaveChanges();
            return entidad;
        }

        public List<Clientes> Consultar()
        {
            return this.conexion.Clientes.ToList();
        }

        public Clientes Actualizar(Clientes entidad)
        {
            this.conexion.Entry<Clientes>(entidad).State = EntityState.Modified;
            this.conexion.SaveChanges();
            return entidad;
        }

        public Clientes Borrar(Clientes entidad)
        {
            this.conexion.Clientes.Remove(entidad);
            this.conexion.SaveChanges();
            return entidad;
        }
    }
}