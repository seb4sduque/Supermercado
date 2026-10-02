using System;
using System.Linq;
using lib_supermercado.entidades;
using lib_supermercado.implementaciones;
using lib_supermercado.interfaces;
using lib_supermercado.Nucleo;

namespace test_supermercado
{
    [TestClass]
    public class InventariosPruebas
    {
        private IConexion conexion;
        private readonly InventariosLogica aplicacion;
        private Inventarios? entidad = null;

        public InventariosPruebas()
        {
            this.conexion = new Conexion();
            this.conexion.StringConexion = Datosgenerales.ObtenerStringConexion();
            this.aplicacion = new InventariosLogica(this.conexion);
        }

        [TestMethod]
        public void Execute()
        {
            Insertar();
            Consultar();
            Actualizar();
            Borrar();
        }

        public void Insertar()
        {
            var sufijo = Guid.NewGuid().ToString("N");
            this.entidad = new Inventarios
            {
                Stock = 10, StockMinimo = 2, Producto = RequerirId(this.conexion.Productos.Select(x => x.Id), "Productos"), Bodega = RequerirId(this.conexion.Bodegas.Select(x => x.Id), "Bodegas")
            };
            this.aplicacion.Insertar(this.entidad);
        }

        public void Consultar()
        {
            var lista = this.aplicacion.Consultar();
            if (this.entidad == null || !lista.Any(x => x.Id == this.entidad.Id))
                throw new Exception("La entidad insertada no aparece en la consulta.");
        }

        private void Actualizar()
        {
            this.entidad!.Stock = 11;
            this.aplicacion.Actualizar(this.entidad!);
            Assert.AreEqual(11, this.aplicacion.Consultar().Single(x => x.Id == this.entidad!.Id).Stock);
        }

        private void Borrar()
        {
            this.aplicacion.Borrar(this.entidad!);
            if (this.aplicacion.Consultar().Any(x => x.Id == this.entidad!.Id))
                throw new Exception("La entidad no se borró.");
            this.entidad = null;
        }

        [TestCleanup]
        public void Cleanup()
        {
            try
            {
                if (this.entidad is { Id: > 0 })
                    this.aplicacion.Borrar(this.entidad);
            }
            finally
            {
                (this.conexion as IDisposable)?.Dispose();
            }
        }

        private static int RequerirId(System.Collections.Generic.IEnumerable<int> ids, string tabla)
        {
            var id = ids.FirstOrDefault();
            if (id <= 0)
                throw new Exception($"Se requiere al menos un registro en {tabla} para cumplir la llave foránea.");
            return id;
        }
    }
}