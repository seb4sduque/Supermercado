using Presentacion_Supermercado.interfaces;

namespace Front_Supermercado.Nucleo
{

    public class Catalogos
    {
        private readonly IPersonasPresentacion personas;
        private readonly IClientesPresentacion clientes;
        private readonly IEmpleadosPresentacion empleados;
        private readonly IMetodosPagoPresentacion metodosPago;
        private readonly ICargosPresentacion cargos;
        private readonly IBodegasPresentacion bodegas;
        private readonly ICategoriasPresentacion categorias;
        private readonly ISubcategoriasPresentacion subcategorias;
        private readonly IProductosPresentacion productos;
        private readonly IProveedoresPresentacion proveedores;
        private readonly IComprasProveedoresPresentacion comprasProveedores;
        private readonly IFacturasPresentacion facturas;
        private readonly IInventariosPresentacion inventarios;
        private readonly ITurnosPresentacion turnos;

        private readonly Dictionary<string, Dictionary<int, string>> cache = new();

        public Catalogos(IPersonasPresentacion personas,
            IClientesPresentacion clientes,
            IEmpleadosPresentacion empleados,
            IMetodosPagoPresentacion metodosPago,
            ICargosPresentacion cargos,
            IBodegasPresentacion bodegas,
            ICategoriasPresentacion categorias,
            ISubcategoriasPresentacion subcategorias,
            IProductosPresentacion productos,
            IProveedoresPresentacion proveedores,
            IComprasProveedoresPresentacion comprasProveedores,
            IFacturasPresentacion facturas,
            IInventariosPresentacion inventarios,
            ITurnosPresentacion turnos)
        {
            this.personas = personas;
            this.clientes = clientes;
            this.empleados = empleados;
            this.metodosPago = metodosPago;
            this.cargos = cargos;
            this.bodegas = bodegas;
            this.categorias = categorias;
            this.subcategorias = subcategorias;
            this.productos = productos;
            this.proveedores = proveedores;
            this.comprasProveedores = comprasProveedores;
            this.facturas = facturas;
            this.inventarios = inventarios;
            this.turnos = turnos;
        }

        private Dictionary<int, string> Obtener(string clave, Func<Dictionary<int, string>> cargar)
        {
            if (!cache.TryGetValue(clave, out var datos))
            {
                datos = cargar();
                cache[clave] = datos;
            }
            return datos;
        }

        public Dictionary<int, string> Personas() => Obtener("Personas", () =>
            personas.Consultar().ToDictionary(x => x.Id, x => x.Nombre));

        public Dictionary<int, string> Clientes() => Obtener("Clientes", () =>
        {
            var p = Personas();
            return clientes.Consultar().ToDictionary(x => x.Id, x => p.GetValueOrDefault(x.Persona, ""));
        });

        public Dictionary<int, string> Empleados() => Obtener("Empleados", () =>
        {
            var p = Personas();
            return empleados.Consultar().ToDictionary(x => x.Id, x => p.GetValueOrDefault(x.Persona, ""));
        });

        public Dictionary<int, string> MetodosPago() => Obtener("MetodosPago", () =>
            metodosPago.Consultar().ToDictionary(x => x.Id, x => x.Nombre));

        public Dictionary<int, string> Cargos() => Obtener("Cargos", () =>
            cargos.Consultar().ToDictionary(x => x.Id, x => x.Nombre));

        public Dictionary<int, string> Bodegas() => Obtener("Bodegas", () =>
            bodegas.Consultar().ToDictionary(x => x.Id, x => x.Nombre));

        public Dictionary<int, string> Categorias() => Obtener("Categorias", () =>
            categorias.Consultar().ToDictionary(x => x.Id, x => x.Nombre));

        public Dictionary<int, string> Subcategorias() => Obtener("Subcategorias", () =>
            subcategorias.Consultar().ToDictionary(x => x.Id, x => x.Nombre));

        public Dictionary<int, string> Productos() => Obtener("Productos", () =>
            productos.Consultar().ToDictionary(x => x.Id, x => x.Nombre));

        public Dictionary<int, string> Proveedores() => Obtener("Proveedores", () =>
            proveedores.Consultar().ToDictionary(x => x.Id, x => x.NombreEmpresa));

        public Dictionary<int, string> Turnos() => Obtener("Turnos", () =>
            turnos.Consultar().ToDictionary(x => x.Id, x => x.Nombre));

        // Las tablas sin nombre propio se describen con sus datos de negocio
        public Dictionary<int, string> ComprasProveedores() => Obtener("ComprasProveedores", () =>
            comprasProveedores.Consultar().ToDictionary(x => x.Id, x => "Compra " + x.NumeroFactura));

        public Dictionary<int, string> Facturas() => Obtener("Facturas", () =>
        {
            var c = Clientes();
            return facturas.Consultar().ToDictionary(x => x.Id,
                x => x.FechaHora.ToString("yyyy-MM-dd HH:mm") + " - " + c.GetValueOrDefault(x.Cliente, ""));
        });

        public Dictionary<int, string> Inventarios() => Obtener("Inventarios", () =>
        {
            var p = Productos();
            var b = Bodegas();
            return inventarios.Consultar().ToDictionary(x => x.Id,
                x => p.GetValueOrDefault(x.Producto, "") + " - " + b.GetValueOrDefault(x.Bodega, ""));
        });
    }
}
