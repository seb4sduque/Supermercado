using lib_supermercado.implementaciones;
using lib_supermercado.interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(opciones =>
{

    opciones.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
});
builder.Services.AddScoped<IConexion, Conexion>();
builder.Services.AddScoped<IBodegasAplicaciones, BodegasLogica>();
builder.Services.AddScoped<ICargosAplicaciones, CargosLogica>();
builder.Services.AddScoped<ICategoriasAplicaciones, CategoriasLogica>();
builder.Services.AddScoped<IClientesAplicaciones, ClientesLogica>();
builder.Services.AddScoped<IComprasProveedoresAplicaciones, ComprasProveedoresLogica>();
builder.Services.AddScoped<ICuentasCobrarAplicaciones, CuentasCobrarLogica>();
builder.Services.AddScoped<IDetallesComprasAplicaciones, DetallesComprasLogica>();
builder.Services.AddScoped<IDetallesFacturasAplicaciones, DetallesFacturasLogica>();
builder.Services.AddScoped<IEmpleadosAplicaciones, EmpleadosLogica>();
builder.Services.AddScoped<IFacturasAplicaciones, FacturasLogica>();
builder.Services.AddScoped<IInventariosAplicaciones, InventariosLogica>();
builder.Services.AddScoped<IMetodosPagoAplicaciones, MetodosPagoLogica>();
builder.Services.AddScoped<IMovimientosInventariosAplicaciones, MovimientosInventariosLogica>();
builder.Services.AddScoped<IPersonasAplicaciones, PersonasLogica>();
builder.Services.AddScoped<IProductosAplicaciones, ProductosLogica>();
builder.Services.AddScoped<IProgramacionTurnosAplicaciones, ProgramacionTurnosLogica>();
builder.Services.AddScoped<IProveedoresAplicaciones, ProveedoresLogica>();
builder.Services.AddScoped<ISubcategoriasAplicaciones, SubcategoriasLogica>();
builder.Services.AddScoped<ISueldoEmpleadosAplicaciones, SueldoEmpleadosLogica>();
builder.Services.AddScoped<ITurnosAplicaciones, TurnosLogica>();

var app = builder.Build();


// Toma el usuario que envía el front y se lo entrega a la conexión (para la auditoría)
app.Use(async (contexto, siguiente) =>
{
    var conexion = contexto.RequestServices.GetRequiredService<IConexion>();
    conexion.UsuarioActual = contexto.Request.Headers["Usuario"].FirstOrDefault();
    await siguiente();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
