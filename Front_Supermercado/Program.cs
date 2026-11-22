using Front_Supermercado.Nucleo;
using Presentacion_Supermercado.implementaciones;
using Presentacion_Supermercado.interfaces;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});

builder.Services.AddScoped<IComunicaciones, Comunicaciones>();
builder.Services.AddScoped<Catalogos>();
builder.Services.AddScoped<IBodegasPresentacion, BodegasPresentacion>();
builder.Services.AddScoped<ICargosPresentacion, CargosPresentacion>();
builder.Services.AddScoped<ICategoriasPresentacion, CategoriasPresentacion>();
builder.Services.AddScoped<IClientesPresentacion, ClientesPresentacion>();
builder.Services.AddScoped<IComprasProveedoresPresentacion, ComprasProveedoresPresentacion>();
builder.Services.AddScoped<ICuentasCobrarPresentacion, CuentasCobrarPresentacion>();
builder.Services.AddScoped<IDetallesComprasPresentacion, DetallesComprasPresentacion>();
builder.Services.AddScoped<IDetallesFacturasPresentacion, DetallesFacturasPresentacion>();
builder.Services.AddScoped<IEmpleadosPresentacion, EmpleadosPresentacion>();
builder.Services.AddScoped<IFacturasPresentacion, FacturasPresentacion>();
builder.Services.AddScoped<IInventariosPresentacion, InventariosPresentacion>();
builder.Services.AddScoped<IMetodosPagoPresentacion, MetodosPagoPresentacion>();
builder.Services.AddScoped<IMovimientosInventariosPresentacion, MovimientosInventariosPresentacion>();
builder.Services.AddScoped<IPersonasPresentacion, PersonasPresentacion>();
builder.Services.AddScoped<IProductosPresentacion, ProductosPresentacion>();
builder.Services.AddScoped<IProgramacionTurnosPresentacion, ProgramacionTurnosPresentacion>();
builder.Services.AddScoped<IProveedoresPresentacion, ProveedoresPresentacion>();
builder.Services.AddScoped<ISubcategoriasPresentacion, SubcategoriasPresentacion>();
builder.Services.AddScoped<ISueldoEmpleadosPresentacion, SueldoEmpleadosPresentacion>();
builder.Services.AddScoped<ITurnosPresentacion, TurnosPresentacion>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

// Los <input type="number"> envían decimales con punto; con cultura es-CO el servidor
// los leería mal. Se fija una cultura con punto decimal para el model binding.
var cultura = new CultureInfo("en-US");
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(cultura),
    SupportedCultures = new List<CultureInfo> { cultura },
    SupportedUICultures = new List<CultureInfo> { cultura }
});

app.UseHttpsRedirection();
app.UseRouting();
app.UseSession();
app.UseAuthorization();
app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();
app.Run();
