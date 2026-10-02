using System;
using System.Linq;
using lib_supermercado.entidades;
using lib_supermercado.implementaciones;
using lib_supermercado.interfaces;
using lib_supermercado.Nucleo;

namespace test_supermercado
{
    [TestClass]
    public class DetallesComprasPruebas
    {
        private IConexion conexion;
        private readonly DetallesComprasLogica aplicacion;
        private DetallesCompras? entidad = null;

        public DetallesComprasPruebas()
        {
            this.conexion = new Conexion();
            this.conexion.StringConexion = Datosgenerales.ObtenerStringConexion();
            this.aplicacion = new DetallesComprasLogica(this.conexion);
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
            this.entidad = new DetallesCompras
            {
                PrecioCompra = 10m, Cantidad = 2, Producto = RequerirId(this.conexion.Productos.Select(x => x.Id), "Productos"), CompraProveedor = RequerirId(this.conexion.ComprasProveedores.Select(x => x.Id), "ComprasProveedores")
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
            this.entidad!.Cantidad = 3;
            this.aplicacion.Actualizar(this.entidad!);
            Assert.AreEqual(3, this.aplicacion.Consultar().Single(x => x.Id == this.entidad!.Id).Cantidad);
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