using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MarcasAutosAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreateMarcasAutosTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "marcas_autos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nombre = table.Column<string>(type: "text", nullable: true),
                    FechaCreacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FechaActualizacion = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    UsuarioCreacion = table.Column<string>(type: "text", nullable: true),
                    UsuarioActualizacion = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_marcas_autos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "marcas_autos",
                columns: new[] { "Id", "FechaActualizacion", "FechaCreacion", "Nombre", "UsuarioActualizacion", "UsuarioCreacion" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2024, 10, 23, 1, 25, 52, 839, DateTimeKind.Utc).AddTicks(5259), "Toyota", null, "admin" },
                    { 2, null, new DateTime(2024, 10, 23, 1, 25, 52, 839, DateTimeKind.Utc).AddTicks(5264), "Ford", null, "admin" },
                    { 3, null, new DateTime(2024, 10, 23, 1, 25, 52, 839, DateTimeKind.Utc).AddTicks(5266), "BMW", null, "admin" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "marcas_autos");
        }
    }
}
