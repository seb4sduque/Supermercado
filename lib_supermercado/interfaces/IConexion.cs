using lib_supermercado.entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;

namespace lib_supermercado.interfaces
{
    public interface IConexion
    {

        string? StringConexion { get; set; }

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

        
        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();

    }
}
