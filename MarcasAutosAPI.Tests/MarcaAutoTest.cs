using MarcasAutosAPI.Data;
using MarcasAutosAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarcasAutosAPI.Tests
{
    public class MarcaAutoTest
    {
        [Fact]
        public void MarcaAuto_Properties_ShouldSetCorrectly()
        {
            var marca = new MarcaAuto
            {
                Id = 1,
                Nombre = "Toyota",
                FechaCreacion = DateTime.UtcNow,
                UsuarioCreacion = "admin"
            };

            Assert.Equal(1, marca.Id);
            Assert.Equal("Toyota", marca.Nombre);
            Assert.NotNull(marca.FechaCreacion);
            Assert.Equal("admin", marca.UsuarioCreacion);
        }

        [Fact]
        public void MarcaAuto_Properties_ShouldUpdateCorrectly()
        {
            var marca = new MarcaAuto
            {
                Id = 1,
                Nombre = "Ford",
                FechaCreacion = DateTime.UtcNow
            };

            marca.Nombre = "BMW";
            marca.FechaActualizacion = DateTime.UtcNow;
            
            Assert.Equal("BMW", marca.Nombre);
            Assert.NotNull(marca.FechaActualizacion);
        }

        [Fact]
        public async Task SeedData_IsInsertedCorrectly()
        {
            var options = new DbContextOptionsBuilder<MarcasAutosContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabaseSeedData")
                .Options;

            using (var context = new MarcasAutosContext(options))
            {
                context.Database.EnsureCreated();
                var marcas = await context.MarcasAutos.ToListAsync();
                Assert.Equal(5, marcas.Count);
                Assert.Contains(marcas, m => m.Nombre == "Toyota");
                Assert.Contains(marcas, m => m.Nombre == "Ford");
                Assert.Contains(marcas, m => m.Nombre == "BMW");
                Assert.Contains(marcas, m => m.Nombre == "NISSAN");
                Assert.Contains(marcas, m => m.Nombre == "AUDI");
            }
        }

        [Fact]
        public void Database_EnsureCreated()
        {
            var options = new DbContextOptionsBuilder<MarcasAutosContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase_Migrations")
                .Options;

            using (var context = new MarcasAutosContext(options))
            {
                bool isCreated = context.Database.EnsureCreated();
                Assert.True(isCreated);
            }
        }

        [Fact]
        public void Model_CreatesCorrectTableName()
        {
            var options = new DbContextOptionsBuilder<MarcasAutosContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase_ModelSnapshot")
                .Options;

            using (var context = new MarcasAutosContext(options))
            {
                var entityType = context.Model.FindEntityType(typeof(MarcaAuto));
                Assert.Equal("marcas_autos", entityType.GetTableName());
            }
        }

    }
}
