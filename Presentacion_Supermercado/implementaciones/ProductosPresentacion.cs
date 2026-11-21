using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.EntityFrameworkCore;
using Presentacion_Supermercado.interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Presentacion_Supermercado.implementaciones
{
    public class ProductosPresentacion : IProductosPresentacion
    {
        private IComunicaciones Icomunicaciones;

        public ProductosPresentacion(IComunicaciones Icomunicacion)
        {
            this.Icomunicaciones = Icomunicacion;
        }

        public Productos Insertar(Productos entidad)
        {
            var task = this.Icomunicaciones.Ejecutar<Productos>(
                "Productos/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Productos> Consultar()
        {
            var task = this.Icomunicaciones.Ejecutar<List<Productos>>(
               "Productos/Consultar",
               null);
            task.Wait();
            return task.Result;
        }

        public Productos Actualizar(Productos entidad)
        {
            var task = this.Icomunicaciones.Ejecutar<Productos>(
                "Productos/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }
        

        public Productos Borrar(Productos entidad)
        {
            var task = this.Icomunicaciones.Ejecutar<Productos>(
                "Productos/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }
    }
}   