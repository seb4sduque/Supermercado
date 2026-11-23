using lib_supermercado.entidades;
using lib_supermercado.interfaces;
using lib_supermercado.Nucleo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace lib_supermercado.implementaciones
{
    public class Conexion : DbContext , IConexion
    {

        public string? StringConexion { get; set; }
        public string? UsuarioActual { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                this.StringConexion ?? Datosgenerales.ObtenerStringConexion(), p => { });
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

        public override int SaveChanges()
        {
            AplicarAuditoria();
            return base.SaveChanges();
        }

        // Llena los campos de auditoría de toda entidad que herede de EntidadAuditable
        private void AplicarAuditoria()
        {
            var ahora = DateTime.Now;
            var usuario = this.UsuarioActual ?? "Sistema";

            foreach (var entrada in this.ChangeTracker.Entries<EntidadAuditable>())
            {
                if (entrada.State == EntityState.Added)
                {
                    entrada.Entity.FechaCreacion = ahora;
                    entrada.Entity.CreadoPor = usuario;
                }
                else if (entrada.State == EntityState.Modified)
                {
                    // Al actualizar no se debe pisar quién y cuándo se creó
                    entrada.Property(nameof(EntidadAuditable.FechaCreacion)).IsModified = false;
                    entrada.Property(nameof(EntidadAuditable.CreadoPor)).IsModified = false;
                    entrada.Entity.FechaModificacion = ahora;
                    entrada.Entity.ModificadoPor = usuario;
                }
            }
        }
    }
}
