using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.EntityFrameworkCore;
using Presentacion_Supermercado.interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Presentacion_Supermercado.implementaciones
{
    public class DetallesFacturasPresentacion : IDetallesFacturasPresentacion
    {
        private IComunicaciones Icomunicaciones;

        public DetallesFacturasPresentacion(IComunicaciones Icomunicacion)
        {
            this.Icomunicaciones = Icomunicacion;
        }

        public DetallesFacturas Insertar(DetallesFacturas entidad)
        {
            var task = this.Icomunicaciones.Ejecutar<DetallesFacturas>(
                "DetallesFacturas/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<DetallesFacturas> Consultar()
        {
            var task = this.Icomunicaciones.Ejecutar<List<DetallesFacturas>>(
                "DetallesFacturas/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public DetallesFacturas Actualizar(DetallesFacturas entidad)
        {
            var task = this.Icomunicaciones.Ejecutar<DetallesFacturas>(
                "DetallesFacturas/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public DetallesFacturas Borrar(DetallesFacturas entidad)
        {
            var task = this.Icomunicaciones.Ejecutar<DetallesFacturas>(
                "DetallesFacturas/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }
    }
}