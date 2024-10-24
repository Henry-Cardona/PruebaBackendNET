using MarcasAutosAPI.Data;
using MarcasAutosAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MarcasAutosAPI.Tests
{
    public class MarcasAutosContextTest
    {
        [Fact]
        public void OnModelCreating_SetsSeedData_Correctly()
        {
            var options = new DbContextOptionsBuilder<MarcasAutosContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase_SeedData")
                .Options;

            using (var context = new MarcasAutosContext(options))
            {
                context.Database.EnsureCreated();

                var marcas = context.MarcasAutos.ToList();

                Assert.Equal(5, marcas.Count);
                Assert.Contains(marcas, m => m.Nombre == "Toyota");
                Assert.Contains(marcas, m => m.Nombre == "Ford");
                Assert.Contains(marcas, m => m.Nombre == "BMW");
            }
        }

        [Fact]
        public void SaveChanges_SetsFechaCreacionAndUsuarioCreacion_OnAdd()
        {
            var options = new DbContextOptionsBuilder<MarcasAutosContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase_SaveChanges")
                .Options;

            using (var context = new MarcasAutosContext(options))
            {
                var nuevaMarca = new MarcaAuto { Nombre = "TestBrand" };

                context.MarcasAutos.Add(nuevaMarca);
                context.SaveChanges();

                Assert.NotNull(nuevaMarca.FechaCreacion);
                Assert.Equal("Sistema", nuevaMarca.UsuarioCreacion);
            }
        }

        [Fact]
        public void SaveChanges_SetsFechaActualizacionAndUsuarioActualizacion_OnModify()
        {
            var options = new DbContextOptionsBuilder<MarcasAutosContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase_SaveChanges_Update")
                .Options;

            using (var context = new MarcasAutosContext(options))
            {
                var marca = new MarcaAuto { Nombre = "TestBrand" };
                context.MarcasAutos.Add(marca);
                context.SaveChanges();

                marca.Nombre = "UpdatedBrand";

                context.MarcasAutos.Update(marca);
                context.SaveChanges();

                Assert.NotNull(marca.FechaActualizacion);
                Assert.Equal("Sistema", marca.UsuarioActualizacion);
            }
        }

        [Fact]
        public void SaveChanges_InsertsMultipleRecords()
        {
            var options = new DbContextOptionsBuilder<MarcasAutosContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase_InsertMultiple")
                .Options;

            using (var context = new MarcasAutosContext(options))
            {
                var marcas = new List<MarcaAuto>
                {
                    new MarcaAuto { Nombre = "Mazda" },
                    new MarcaAuto { Nombre = "Chevrolet" }
                };

                context.MarcasAutos.AddRange(marcas);
                context.SaveChanges();

                var allMarcas = context.MarcasAutos.ToList();
                Assert.Equal(2, allMarcas.Count);
                Assert.Contains(allMarcas, m => m.Nombre == "Mazda");
                Assert.Contains(allMarcas, m => m.Nombre == "Chevrolet");
            }
        }

        [Fact]
        public void SaveChanges_UpdatesRecordCorrectly()
        {
            var options = new DbContextOptionsBuilder<MarcasAutosContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase_UpdateRecord")
                .Options;

            using (var context = new MarcasAutosContext(options))
            {
                var marca = new MarcaAuto { Nombre = "Peugeot" };
                context.MarcasAutos.Add(marca);
                context.SaveChanges();

                marca.Nombre = "Peugeot Updated";
                context.MarcasAutos.Update(marca);
                context.SaveChanges();

                var updatedMarca = context.MarcasAutos.First(m => m.Id == marca.Id);
                Assert.Equal("Peugeot Updated", updatedMarca.Nombre);
                Assert.NotNull(updatedMarca.FechaActualizacion);
                Assert.Equal("Sistema", updatedMarca.UsuarioActualizacion);
            }
        }

        [Fact]
        public void SaveChanges_DeletesRecord()
        {
            var options = new DbContextOptionsBuilder<MarcasAutosContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase_DeleteRecord")
                .Options;

            using (var context = new MarcasAutosContext(options))
            {
                var marca = new MarcaAuto { Nombre = "Honda" };
                context.MarcasAutos.Add(marca);
                context.SaveChanges();

                context.MarcasAutos.Remove(marca);
                context.SaveChanges();

                var allMarcas = context.MarcasAutos.ToList();
                Assert.DoesNotContain(allMarcas, m => m.Nombre == "Honda");
            }
        }

        [Fact]
        public void OnModelCreating_ConfiguresModelCorrectly()
        {
            var options = new DbContextOptionsBuilder<MarcasAutosContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase_OnModelCreating")
                .Options;

            using (var context = new MarcasAutosContext(options))
            {
                context.Database.EnsureCreated();
                var entityType = context.Model.FindEntityType(typeof(MarcaAuto));

                Assert.Equal("marcas_autos", entityType.GetTableName());
                Assert.Equal(5, context.MarcasAutos.Count());
            }
        }

        [Fact]
        public void SaveChanges_DoesNotChangeFechaCreacion_OnUpdate()
        {
            var options = new DbContextOptionsBuilder<MarcasAutosContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase_NoChangeFechaCreacion")
                .Options;

            using (var context = new MarcasAutosContext(options))
            {
                var marca = new MarcaAuto { Nombre = "OriginalBrand", FechaCreacion = DateTime.UtcNow };
                context.MarcasAutos.Add(marca);
                context.SaveChanges();

                var originalFechaCreacion = marca.FechaCreacion;

                marca.Nombre = "UpdatedBrand";
                context.MarcasAutos.Update(marca);
                context.SaveChanges();
                Assert.Equal(originalFechaCreacion, marca.FechaCreacion);
            }
        }

        [Fact]
        public void SaveChanges_OnlyUpdatesNombreField()
        {
            var options = new DbContextOptionsBuilder<MarcasAutosContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase_OnlyUpdateNombre")
                .Options;

            using (var context = new MarcasAutosContext(options))
            {
                var marca = new MarcaAuto { Nombre = "OldBrand", FechaCreacion = DateTime.UtcNow };
                context.MarcasAutos.Add(marca);
                context.SaveChanges();

                var originalFechaCreacion = marca.FechaCreacion;

                marca.Nombre = "NewBrand";
                context.Entry(marca).Property(m => m.Nombre).IsModified = true;
                context.SaveChanges();

                Assert.Equal(originalFechaCreacion, marca.FechaCreacion);
                Assert.Equal("NewBrand", marca.Nombre);
            }
        }

        [Fact]
        public void ChangeTracker_VerifiesEntityStateCorrectly()
        {
            var options = new DbContextOptionsBuilder<MarcasAutosContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase_ChangeTracker")
                .Options;

            using (var context = new MarcasAutosContext(options))
            {
                var nuevaMarca = new MarcaAuto { Nombre = "TestBrand" };
                context.MarcasAutos.Add(nuevaMarca);

                var entry = context.Entry(nuevaMarca);
                Assert.Equal(EntityState.Added, entry.State);
                context.SaveChanges();
                Assert.Equal(EntityState.Unchanged, entry.State);
            }
        }

        [Fact]
        public void SaveChanges_CascadesDeletion()
        {
            var options = new DbContextOptionsBuilder<MarcasAutosContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase_CascadeDelete")
                .Options;

            using (var context = new MarcasAutosContext(options))
            {
                var marca = new MarcaAuto { Nombre = "TestBrand" };

                context.MarcasAutos.Add(marca);
                context.SaveChanges();

                context.MarcasAutos.Remove(marca);
                context.SaveChanges();
                Assert.DoesNotContain(context.MarcasAutos, m => m.Nombre == "TestBrand");
            }
        }

    }
}
