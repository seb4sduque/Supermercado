using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.EntityFrameworkCore;
using Presentacion_Supermercado.interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Presentacion_Supermercado.implementaciones
{
    public class InventariosPresentacion : IInventariosAplicaciones
    {
        private IComunicaciones Icomunicaciones;

        public InventariosPresentacion(IComunicaciones Icomunicacion)
        {
            this.Icomunicaciones = Icomunicacion;
        }

        public Inventarios Insertar(Inventarios entidad)
        {
            var task = this.Icomunicaciones.Ejecutar<Inventarios>(
               "Inventarios/Insertar",
               entidad);
            task.Wait();
            return task.Result;
        }

        public List<Inventarios> Consultar()
        {
            var task = this.Icomunicaciones.Ejecutar<List<Inventarios>>(
                "Inventarios/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Inventarios Actualizar(Inventarios entidad)
        {
            var task = this.Icomunicaciones.Ejecutar<Inventarios>(
                "Inventarios/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Inventarios Borrar(Inventarios entidad)
        {
            var task = this.Icomunicaciones.Ejecutar<Inventarios>(
                "Inventarios/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }
    }
}