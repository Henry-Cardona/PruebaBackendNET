using MarcasAutosAPI.Controllers;
using MarcasAutosAPI.Data;
using MarcasAutosAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MarcasAutosAPI.Tests
{
    public class MarcasAutosControllerTest
    {
        [Fact]
        public async Task GetMarcasAutos_ReturnsOk_WhenBrandsExist()
        {
            var options = new DbContextOptionsBuilder<MarcasAutosContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new MarcasAutosContext(options))
            {
                context.MarcasAutos.Add(new MarcaAuto { Id = 1, Nombre = "Toyota" });
                context.MarcasAutos.Add(new MarcaAuto { Id = 2, Nombre = "Ford" });
                context.SaveChanges();

                var controller = new MarcasAutosController(context);

                var result = await controller.GetMarcasAutos();
                var actionResult = Assert.IsType<OkObjectResult>(result.Result);
                var returnValue = Assert.IsType<List<MarcaAuto>>(actionResult.Value);
                Assert.Equal(2, returnValue.Count);
            }
        }

        [Fact]
        public async Task GetMarcasAutos_ReturnsNotFound_WhenNoBrandsExist()
        {
            var options = new DbContextOptionsBuilder<MarcasAutosContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabaseEmpty")
                .Options;

            using (var context = new MarcasAutosContext(options))
            {
                var controller = new MarcasAutosController(context);
                var result = await controller.GetMarcasAutos();
                Assert.IsType<NotFoundResult>(result.Result);
            }
        }

        [Fact]
        public async Task GetMarcasAutos_ReturnsOk_WithMultipleBrands()
        {
            var options = new DbContextOptionsBuilder<MarcasAutosContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabaseMultipleBrands")
                .Options;

            using (var context = new MarcasAutosContext(options))
            {
                context.MarcasAutos.Add(new MarcaAuto { Id = 1, Nombre = "Toyota" });
                context.MarcasAutos.Add(new MarcaAuto { Id = 2, Nombre = "Ford" });
                context.MarcasAutos.Add(new MarcaAuto { Id = 3, Nombre = "Honda" });
                context.SaveChanges();

                var controller = new MarcasAutosController(context);
                var result = await controller.GetMarcasAutos();

                var actionResult = Assert.IsType<OkObjectResult>(result.Result);
                var returnValue = Assert.IsType<List<MarcaAuto>>(actionResult.Value);
                Assert.Equal(3, returnValue.Count);
            }
        }

        [Fact]
        public async Task GetMarcasAutos_ReturnsCorrectBrandDetails()
        {
            var options = new DbContextOptionsBuilder<MarcasAutosContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabaseBrandDetails")
                .Options;

            using (var context = new MarcasAutosContext(options))
            {
                context.MarcasAutos.Add(new MarcaAuto { Id = 1, Nombre = "Toyota" });
                context.MarcasAutos.Add(new MarcaAuto { Id = 2, Nombre = "Ford" });
                context.SaveChanges();

                var controller = new MarcasAutosController(context);

                var result = await controller.GetMarcasAutos();

                var actionResult = Assert.IsType<OkObjectResult>(result.Result);
                var returnValue = Assert.IsType<List<MarcaAuto>>(actionResult.Value);
                var toyota = returnValue.FirstOrDefault(m => m.Id == 1);
                var ford = returnValue.FirstOrDefault(m => m.Id == 2);

                Assert.NotNull(toyota);
                Assert.Equal("Toyota", toyota.Nombre);

                Assert.NotNull(ford);
                Assert.Equal("Ford", ford.Nombre);
            }
        }

        [Fact]
        public async Task GetMarcasAutos_ReturnsNotFound_WithEmptyList()
        {
            var options = new DbContextOptionsBuilder<MarcasAutosContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabaseEmptyList")
                .Options;

            using (var context = new MarcasAutosContext(options))
            {
                var controller = new MarcasAutosController(context);
                var result = await controller.GetMarcasAutos();
                Assert.IsType<NotFoundResult>(result.Result);
            }
        }

        [Fact]
        public async Task GetMarcasAutos_ReturnsOk_WithSingleBrand()
        {
            var options = new DbContextOptionsBuilder<MarcasAutosContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabaseSingleBrand")
                .Options;

            using (var context = new MarcasAutosContext(options))
            {
                context.MarcasAutos.Add(new MarcaAuto { Id = 1, Nombre = "Nissan" });
                context.SaveChanges();

                var controller = new MarcasAutosController(context);
                var result = await controller.GetMarcasAutos();

                var actionResult = Assert.IsType<OkObjectResult>(result.Result);
                var returnValue = Assert.IsType<List<MarcaAuto>>(actionResult.Value);
                Assert.Single(returnValue);
                Assert.Equal("Nissan", returnValue[0].Nombre);
            }
        }

        [Fact]
        public async Task GetMarcasAutos_ReturnsOk_WithManyBrands()
        {
            var options = new DbContextOptionsBuilder<MarcasAutosContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabaseManyBrands")
                .Options;

            using (var context = new MarcasAutosContext(options))
            {
                for (int i = 1; i <= 100; i++)
                {
                    context.MarcasAutos.Add(new MarcaAuto { Id = i, Nombre = $"Brand{i}" });
                }
                context.SaveChanges();

                var controller = new MarcasAutosController(context);
                var result = await controller.GetMarcasAutos();

                var actionResult = Assert.IsType<OkObjectResult>(result.Result);
                var returnValue = Assert.IsType<List<MarcaAuto>>(actionResult.Value);
                Assert.Equal(100, returnValue.Count);
            }
        }

        [Fact]
        public async Task GetMarcasAutos_ReturnsNotFound_WhenDataIsNull()
        {
            var options = new DbContextOptionsBuilder<MarcasAutosContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabaseNullData")
                .Options;

            using (var context = new MarcasAutosContext(options))
            {
                var controller = new MarcasAutosController(context);
                var result = await controller.GetMarcasAutos();
                Assert.IsType<NotFoundResult>(result.Result);
            }
        }

        [Fact]
        public async Task GetMarcasAutos_ReturnsOk_WithLargeNumberOfBrands()
        {
            var options = new DbContextOptionsBuilder<MarcasAutosContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabaseWithLargeData")
                .Options;

            using (var context = new MarcasAutosContext(options))
            {
                for (int i = 1; i <= 10000; i++)
                {
                    context.MarcasAutos.Add(new MarcaAuto { Id = i, Nombre = $"Brand{i}" });
                }
                context.SaveChanges();

                var controller = new MarcasAutosController(context);

                var result = await controller.GetMarcasAutos();

                var actionResult = Assert.IsType<OkObjectResult>(result.Result);
                var returnValue = Assert.IsType<List<MarcaAuto>>(actionResult.Value);
                Assert.Equal(10000, returnValue.Count);
            }
        }

        [Fact]
        public async Task GetMarcasAutos_ReturnsOk_WhenDatabaseHasDuplicateNames()
        {
            var options = new DbContextOptionsBuilder<MarcasAutosContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabaseWithDuplicateNames")
                .Options;

            using (var context = new MarcasAutosContext(options))
            {
                context.MarcasAutos.Add(new MarcaAuto { Id = 1, Nombre = "Toyota" });
                context.MarcasAutos.Add(new MarcaAuto { Id = 2, Nombre = "Toyota" });
                context.SaveChanges();

                var controller = new MarcasAutosController(context);

                var result = await controller.GetMarcasAutos();

                var actionResult = Assert.IsType<OkObjectResult>(result.Result);
                var returnValue = Assert.IsType<List<MarcaAuto>>(actionResult.Value);
                Assert.Equal(2, returnValue.Count);
            }
        }

        [Fact]
        public async Task GetMarcasAutos_ReturnsOk_WhenDatabaseHasDuplicateData()
        {
            var options = new DbContextOptionsBuilder<MarcasAutosContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabaseWithDuplicates")
                .Options;

            using (var context = new MarcasAutosContext(options))
            {
                context.MarcasAutos.Add(new MarcaAuto { Id = 1, Nombre = "Toyota" });
                context.MarcasAutos.Add(new MarcaAuto { Id = 2, Nombre = "Toyota" });
                context.SaveChanges();

                var controller = new MarcasAutosController(context);

                var result = await controller.GetMarcasAutos();

                var actionResult = Assert.IsType<OkObjectResult>(result.Result);
                var returnValue = Assert.IsType<List<MarcaAuto>>(actionResult.Value);
                Assert.Equal(2, returnValue.Count);
            }
        }

    }
}