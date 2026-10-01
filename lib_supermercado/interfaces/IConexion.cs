using lib_supermercado.entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace lib_supermercado.interfaces
{
    public interface IConexion
    {
        string? StringConexion { get; set; }

        DbSet<Bodegas>? Bodegas { get; set; }

        EntityEntry<T> Entry<T>(T entity) where T : class;
        int SaveChanges();
    }
}
