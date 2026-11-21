using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.EntityFrameworkCore;
using Presentacion_Supermercado.interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Presentacion_Supermercado.implementaciones
{
    public class MetodosPagoPresentacion : IMetodosPagoPresentacion
    {
        private IComunicaciones Icomunicaciones;

        public MetodosPagoPresentacion(IComunicaciones Icomunicacion)
        {
            this.Icomunicaciones = Icomunicacion;
        }

        public MetodosPago Insertar(MetodosPago entidad)
        {
            var task = this.Icomunicaciones.Ejecutar<MetodosPago>(
                "MetodosPago/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<MetodosPago> Consultar()
        {
            var task = this.Icomunicaciones.Ejecutar<List<MetodosPago>>(
                "MetodosPago/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public MetodosPago Actualizar(MetodosPago entidad)
        {
            var task = this.Icomunicaciones.Ejecutar<MetodosPago>(
                "MetodosPago/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
            
        }

        public MetodosPago Borrar(MetodosPago entidad)
        {
            var task = this.Icomunicaciones.Ejecutar<MetodosPago>(
                "MetodosPago/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }
    }
}