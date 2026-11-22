using lib_supermercado.entidades;
using Presentacion_Supermercado.interfaces;

namespace Presentacion_Supermercado.implementaciones
{
    public class SubcategoriasPresentacion : ISubcategoriasPresentacion
    {
        private IComunicaciones Icomunicaciones;

        public SubcategoriasPresentacion(IComunicaciones Icomunicacion)
        {
            this.Icomunicaciones = Icomunicacion;
        }

        public Subcategorias Insertar(Subcategorias entidad)
        {
            var task = this.Icomunicaciones.Ejecutar<Subcategorias>(
                "Subcategorias/Insertar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public List<Subcategorias> Consultar()
        {
            var task = this.Icomunicaciones.Ejecutar<List<Subcategorias>>(
                "Subcategorias/Consultar",
                null!);
            task.Wait();
            return task.Result;
        }

        public Subcategorias Actualizar(Subcategorias entidad)
        {
            var task = this.Icomunicaciones.Ejecutar<Subcategorias>(
                "Subcategorias/Actualizar",
                entidad);
            task.Wait();
            return task.Result;
        }

        public Subcategorias Borrar(Subcategorias entidad)
        {
            var task = this.Icomunicaciones.Ejecutar<Subcategorias>(
                "Subcategorias/Borrar",
                entidad);
            task.Wait();
            return task.Result;
        }
    }
}
