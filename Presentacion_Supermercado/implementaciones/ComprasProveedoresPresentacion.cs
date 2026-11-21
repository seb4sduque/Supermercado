using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.EntityFrameworkCore;
using Presentacion_Supermercado.interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Presentacion_Supermercado.implementaciones
{
    public class ComprasProveedoresPresentacion : IComprasProveedoresPresentacion
    {
        private IComunicaciones Icomunicaciones;

        public ComprasProveedoresPresentacion(IComunicaciones Icomunicacion)
        {
            this.Icomunicaciones = Icomunicacion;
        }

        public ComprasProveedores Insertar(ComprasProveedores entidad)
        {
            var task = this.Icomunicaciones.Ejecutar<ComprasProveedores>(
                "ComprasProveedores/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<ComprasProveedores> Consultar()
        {
            var task = this.Icomunicaciones.Ejecutar<List<ComprasProveedores>>(
                "ComprasProveedores/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public ComprasProveedores Actualizar(ComprasProveedores entidad)
        {
            var task = this.Icomunicaciones.Ejecutar<ComprasProveedores>(
                "ComprasProveedores/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public ComprasProveedores Borrar(ComprasProveedores entidad)
        {
            var task = this.Icomunicaciones.Ejecutar<ComprasProveedores>(
                "ComprasProveedores/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }
    }
}