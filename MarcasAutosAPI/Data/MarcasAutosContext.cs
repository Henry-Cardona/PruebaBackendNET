using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using MarcasAutosAPI.Models;
using System;
using System.Linq;

namespace MarcasAutosAPI.Data
{
    public class MarcasAutosContext : DbContext
    {
        public DbSet<MarcaAuto> MarcasAutos { get; set; }

        public MarcasAutosContext(DbContextOptions<MarcasAutosContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mapeo de la tabla "marcas_autos"
            modelBuilder.Entity<MarcaAuto>().ToTable("marcas_autos");

            // Datos iniciales (Seed Data)
            modelBuilder.Entity<MarcaAuto>().HasData(
                new MarcaAuto
                {
                    Id = 1,
                    Nombre = "Toyota",
                    FechaCreacion = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),  // Fecha en UTC
                    UsuarioCreacion = "admin"
                },
                new MarcaAuto
                {
                    Id = 2,
                    Nombre = "Ford",
                    FechaCreacion = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),  // Fecha en UTC
                    UsuarioCreacion = "admin"
                },
                new MarcaAuto
                {
                    Id = 3,
                    Nombre = "BMW",
                    FechaCreacion = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),  // Fecha en UTC
                    UsuarioCreacion = "admin"
                },
                new MarcaAuto
                {
                    Id = 4,
                    Nombre = "NISSAN",
                    FechaCreacion = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),  // Fecha en UTC
                    UsuarioCreacion = "admin"
                },
                new MarcaAuto
                {
                    Id = 5,
                    Nombre = "AUDI",
                    FechaCreacion = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc),  // Fecha en UTC
                    UsuarioCreacion = "admin"
                }
            );
        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is MarcaAuto &&
                            (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                var marca = (MarcaAuto)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    marca.FechaCreacion = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);  // Fechas en UTC
                    marca.UsuarioCreacion = "Sistema";
                }
                else if (entry.State == EntityState.Modified)
                {
                    marca.FechaActualizacion = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Utc);  // Fechas en UTC
                    marca.UsuarioActualizacion = "Sistema";
                }
            }

            return base.SaveChanges();
        }
    }
}
