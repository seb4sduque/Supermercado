using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace lib_supermercado.implementaciones
{
    public class Conexion : DbContext , IConexion
    {

        public string? StringConexion { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(this.StringConexion!, p => { });
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        public DbSet<Bodegas> Bodegas { get; set; } 
        public DbSet<Cargos> Cargos { get; set; } 
        public DbSet<Categorias> Categorias { get; set; } 
        public DbSet<Clientes> Clientes { get; set; } 
        public DbSet<ComprasProveedores> ComprasProveedores { get; set; } 
        public DbSet<CuentasCobrar> CuentasCobrar { get; set; } 
        public DbSet<DetallesCompras> DetallesCompras { get; set; } 
        public DbSet<DetallesFacturas> DetallesFacturas { get; set; } 
        public DbSet<Empleados> Empleados { get; set; } 
        public DbSet<Facturas> Facturas { get; set; } 
        public DbSet<Inventarios> Inventarios { get; set; } 
        public DbSet<MetodosPago> MetodosPago { get; set; } 
        public DbSet<MovimientosInventarios> MovimientosInventarios { get; set; } 
        public DbSet<Personas> Personas { get; set; } 
        public DbSet<Productos> Productos { get; set; } 
        public DbSet<ProgramacionTurnos> ProgramacionTurnos { get; set; } 
        public DbSet<Proveedores> Proveedores { get; set; } 
        public DbSet<Subcategorias> Subcategorias { get; set; } 
        public DbSet<SueldoEmpleados> SueldoEmpleados { get; set; } 
        public DbSet<Turnos> Turnos { get; set; } 

    }
}
