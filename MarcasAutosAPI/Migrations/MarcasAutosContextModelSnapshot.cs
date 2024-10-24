﻿// <auto-generated />
using System;
using MarcasAutosAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MarcasAutosAPI.Migrations
{
    [DbContext(typeof(MarcasAutosContext))]
    partial class MarcasAutosContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("MarcasAutosAPI.Models.MarcaAuto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("FechaActualizacion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Nombre")
                        .HasColumnType("text");

                    b.Property<string>("UsuarioActualizacion")
                        .HasColumnType("text");

                    b.Property<string>("UsuarioCreacion")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("marcas_autos", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FechaCreacion = new DateTime(2024, 10, 23, 5, 50, 44, 117, DateTimeKind.Utc).AddTicks(5009),
                            Nombre = "Toyota",
                            UsuarioCreacion = "admin"
                        },
                        new
                        {
                            Id = 2,
                            FechaCreacion = new DateTime(2024, 10, 23, 5, 50, 44, 117, DateTimeKind.Utc).AddTicks(5017),
                            Nombre = "Ford",
                            UsuarioCreacion = "admin"
                        },
                        new
                        {
                            Id = 3,
                            FechaCreacion = new DateTime(2024, 10, 23, 5, 50, 44, 117, DateTimeKind.Utc).AddTicks(5018),
                            Nombre = "BMW",
                            UsuarioCreacion = "admin"
                        },
                        new
                        {
                            Id = 4,
                            FechaCreacion = new DateTime(2024, 10, 23, 5, 50, 44, 117, DateTimeKind.Utc).AddTicks(5020),
                            Nombre = "NISSAN",
                            UsuarioCreacion = "admin"
                        },
                        new
                        {
                            Id = 5,
                            FechaCreacion = new DateTime(2024, 10, 23, 5, 50, 44, 117, DateTimeKind.Utc).AddTicks(5020),
                            Nombre = "AUDI",
                            UsuarioCreacion = "admin"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
