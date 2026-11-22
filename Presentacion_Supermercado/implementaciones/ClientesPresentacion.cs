using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.EntityFrameworkCore;
using Presentacion_Supermercado.interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Presentacion_Supermercado.implementaciones
{
    public class ClientesPresentacion : IClientesPresentacion
    {
        private IComunicaciones Icomunicaciones;

        public ClientesPresentacion(IComunicaciones Icomunicacion)
        {
            this.Icomunicaciones = Icomunicacion;
        }

        public Clientes Insertar(Clientes entidad)
        {
            var task = this.Icomunicaciones.Ejecutar<Clientes>(
                "Clientes/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Clientes> Consultar()
        {
            var task = this.Icomunicaciones.Ejecutar<List<Clientes>>(
                "Clientes/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Clientes Actualizar(Clientes entidad)
        {
            var task = this.Icomunicaciones.Ejecutar<Clientes>(
                "Clientes/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Clientes Borrar(Clientes entidad)
        {
            var task = this.Icomunicaciones.Ejecutar<Clientes>(
                "Clientes/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }
    }
}