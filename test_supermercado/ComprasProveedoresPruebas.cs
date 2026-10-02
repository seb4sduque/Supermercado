using System;
using System.Linq;
using lib_supermercado.entidades;
using lib_supermercado.implementaciones;
using lib_supermercado.interfaces;
using lib_supermercado.Nucleo;

namespace test_supermercado
{
    [TestClass]
    public class ComprasProveedoresPruebas
    {
        private IConexion conexion;
        private readonly ComprasProveedoresLogica aplicacion;
        private ComprasProveedores? entidad = null;

        public ComprasProveedoresPruebas()
        {
            this.conexion = new Conexion();
            this.conexion.StringConexion = Datosgenerales.ObtenerStringConexion();
            this.aplicacion = new ComprasProveedoresLogica(this.conexion);
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
            this.entidad = new ComprasProveedores
            {
                NumeroFactura = 999999, FechaCompra = DateTime.Now, TotalCompra = 100m, Proveedor = RequerirId(this.conexion.Proveedores.Select(x => x.Id), "Proveedores")
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
            this.entidad!.TotalCompra = 200m;
            this.aplicacion.Actualizar(this.entidad!);
            Assert.AreEqual(200m, this.aplicacion.Consultar().Single(x => x.Id == this.entidad!.Id).TotalCompra);
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