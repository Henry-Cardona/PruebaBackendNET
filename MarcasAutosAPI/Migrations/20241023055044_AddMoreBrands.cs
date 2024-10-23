using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MarcasAutosAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddMoreBrands : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "marcas_autos",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 23, 5, 50, 44, 117, DateTimeKind.Utc).AddTicks(5009));

            migrationBuilder.UpdateData(
                table: "marcas_autos",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 23, 5, 50, 44, 117, DateTimeKind.Utc).AddTicks(5017));

            migrationBuilder.UpdateData(
                table: "marcas_autos",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 23, 5, 50, 44, 117, DateTimeKind.Utc).AddTicks(5018));

            migrationBuilder.InsertData(
                table: "marcas_autos",
                columns: new[] { "Id", "FechaActualizacion", "FechaCreacion", "Nombre", "UsuarioActualizacion", "UsuarioCreacion" },
                values: new object[,]
                {
                    { 4, null, new DateTime(2024, 10, 23, 5, 50, 44, 117, DateTimeKind.Utc).AddTicks(5020), "NISSAN", null, "admin" },
                    { 5, null, new DateTime(2024, 10, 23, 5, 50, 44, 117, DateTimeKind.Utc).AddTicks(5020), "AUDI", null, "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "marcas_autos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "marcas_autos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.UpdateData(
                table: "marcas_autos",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 23, 1, 25, 52, 839, DateTimeKind.Utc).AddTicks(5259));

            migrationBuilder.UpdateData(
                table: "marcas_autos",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 23, 1, 25, 52, 839, DateTimeKind.Utc).AddTicks(5264));

            migrationBuilder.UpdateData(
                table: "marcas_autos",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2024, 10, 23, 1, 25, 52, 839, DateTimeKind.Utc).AddTicks(5266));
        }
    }
}
