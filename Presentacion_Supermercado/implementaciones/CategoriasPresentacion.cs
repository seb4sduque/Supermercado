using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.EntityFrameworkCore;
using Presentacion_Supermercado.interfaces;
using System.Collections.Generic;
using System.Linq;

namespace lib_supermercado.implementaciones
{
    public class CategoriasPresentacion : ICategoriasPresentacion
    {
        private IComunicaciones IComunicaciones;

        public CategoriasPresentacion(IComunicaciones Icomunicacion)
        {
            this.IComunicaciones = Icomunicacion;
        }

        public Categorias Insertar(Categorias entidad)
        {
            if (entidad.Id != 0)
                throw new Exception("Ya se guardo");

            var task = this.IComunicaciones.Ejecutar<Categorias>(
                "Categorias/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Categorias> Consultar()
        {
            var task = this.IComunicaciones.Ejecutar<List<Categorias>>(
                "Categorias/Consultar",
                null);
            task.Wait();
            return task.Result;
        }

        public Categorias Actualizar(Categorias entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Categorias>(
                "Categorias/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Categorias Borrar(Categorias entidad)
        {
            if (entidad.Id == 0)
                throw new Exception("No se ha guardo");

            var task = this.IComunicaciones.Ejecutar<Categorias>(
                "Categorias/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }
    }
}