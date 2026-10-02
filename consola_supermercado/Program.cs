using lib_supermercado.implementaciones;
using lib_supermercado.interfaces;
using lib_supermercado.entidades;
using lib_supermercado.Nucleo;

try
{
    IConexion conexion = new Conexion();
    conexion.StringConexion = Datosgenerales.ObtenerStringConexion();

    var Bodegas = conexion.Bodegas!.ToList();//
    var Cargos = conexion.Cargos!.ToList();//
    var Categorias = conexion.Categorias!.ToList(); //
    var Clientes = conexion.Clientes!.ToList();
    var ComprasProveedores = conexion.ComprasProveedores!.ToList();
    var CuentasCobrar = conexion.CuentasCobrar!.ToList();
    var DetallesCompras = conexion.DetallesCompras!.ToList();
    var DetallesFacturas = conexion.DetallesFacturas!.ToList();
    var Empleados = conexion.Empleados!.ToList();
    var Facturas = conexion.Facturas!.ToList();
    var Inventarios = conexion.Inventarios!.ToList();
    var MetodosPago = conexion.MetodosPago!.ToList();
    var MovimientosInventarios = conexion.MovimientosInventarios!.ToList();
    var Personas = conexion.Personas!.ToList();
    var Productos = conexion.Productos!.ToList();
    var ProgramacionTurnos = conexion.ProgramacionTurnos!.ToList();
    var Proveedores = conexion.Proveedores!.ToList();
    var Subcategorias = conexion.Subcategorias!.ToList();
    var SueldoEmpleados = conexion.SueldoEmpleados!.ToList();
    var Turnos = conexion.Turnos!.ToList();


}
catch (Exception ex)
{

    Console.WriteLine(ex.ToString());
}

Console.WriteLine("presentacion_csn");