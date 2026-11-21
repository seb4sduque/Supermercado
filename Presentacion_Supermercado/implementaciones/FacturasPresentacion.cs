using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.EntityFrameworkCore;
using Presentacion_Supermercado.interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Presentacion_Supermercado.implementaciones
{
    public class FacturasPresentacion : IFacturasPresentacion
    {
        private IComunicaciones Icomunicaciones;

        public FacturasPresentacion(IComunicaciones Icomunicacion)
        {
            this.Icomunicaciones = Icomunicacion;
        }

        public Facturas Insertar(Facturas entidad)
        {
            var task = this.Icomunicaciones.Ejecutar<Facturas>(
                "Facturas/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Facturas> Consultar()
        {
            var task = this.Icomunicaciones.Ejecutar<List<Facturas>>(
                "Facturas/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Facturas Actualizar(Facturas entidad)
        {
            var task = this.Icomunicaciones.Ejecutar<Facturas>(
                "Facturas/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }   
            

        public Facturas Borrar(Facturas entidad)
        {
            var task = this.Icomunicaciones.Ejecutar<Facturas>(
                "Facturas/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }
    }
}