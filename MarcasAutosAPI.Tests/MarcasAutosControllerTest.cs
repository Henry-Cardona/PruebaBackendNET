using MarcasAutosAPI.Controllers;
using MarcasAutosAPI.Data;
using MarcasAutosAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace MarcasAutosAPI.Tests
{
    public class MarcasAutosControllerTest
    {
        // Test cuando hay marcas en la base de datos
        [Fact]
        public async Task GetMarcasAutos_ReturnsOk_WhenBrandsExist()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<MarcasAutosContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new MarcasAutosContext(options))
            {
                context.MarcasAutos.Add(new MarcaAuto { Id = 1, Nombre = "Toyota" });
                context.MarcasAutos.Add(new MarcaAuto { Id = 2, Nombre = "Ford" });
                context.SaveChanges();

                var controller = new MarcasAutosController(context);

                // Act
                var result = await controller.GetMarcasAutos();

                // Assert
                var actionResult = Assert.IsType<OkObjectResult>(result.Result);
                var returnValue = Assert.IsType<List<MarcaAuto>>(actionResult.Value);
                Assert.Equal(2, returnValue.Count);  // Verifica que hay 2 marcas
            }
        }

        // Test cuando no hay marcas en la base de datos
        [Fact]
        public async Task GetMarcasAutos_ReturnsNotFound_WhenNoBrandsExist()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<MarcasAutosContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabaseEmpty")
                .Options;

            using (var context = new MarcasAutosContext(options))
            {
                var controller = new MarcasAutosController(context);

                // Act
                var result = await controller.GetMarcasAutos();

                // Assert
                Assert.IsType<NotFoundResult>(result.Result);  // Verifica que devuelve NotFound cuando no hay marcas
            }
        }
    }
}
