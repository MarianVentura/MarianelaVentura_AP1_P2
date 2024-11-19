﻿// <auto-generated />
using System;
using MarianelaVentura_AP1_P2.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MarianelaVentura_AP1_P2.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20241118232847_Inicial")]
    partial class Inicial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MarianelaVentura_AP1_P2.Models.Articulos", b =>
                {
                    b.Property<int>("ArticuloId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArticuloId"));

                    b.Property<decimal>("Costo")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Existencia")
                        .HasColumnType("int");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ArticuloId");

                    b.ToTable("Articulos");

                    b.HasData(
                        new
                        {
                            ArticuloId = 1,
                            Costo = 250m,
                            Descripcion = "Procesador Intel Core i7",
                            Existencia = 15,
                            Precio = 400m
                        },
                        new
                        {
                            ArticuloId = 2,
                            Costo = 80m,
                            Descripcion = "Memoria RAM 16GB DDR4",
                            Existencia = 20,
                            Precio = 150m
                        },
                        new
                        {
                            ArticuloId = 3,
                            Costo = 60m,
                            Descripcion = "Disco Duro SSD 500GB",
                            Existencia = 25,
                            Precio = 120m
                        },
                        new
                        {
                            ArticuloId = 4,
                            Costo = 300m,
                            Descripcion = "Tarjeta Gráfica NVIDIA RTX 3060",
                            Existencia = 10,
                            Precio = 600m
                        },
                        new
                        {
                            ArticuloId = 5,
                            Costo = 70m,
                            Descripcion = "Fuente de Poder 650W",
                            Existencia = 18,
                            Precio = 120m
                        },
                        new
                        {
                            ArticuloId = 6,
                            Costo = 200m,
                            Descripcion = "Placa Base ASUS ROG",
                            Existencia = 12,
                            Precio = 350m
                        },
                        new
                        {
                            ArticuloId = 7,
                            Costo = 150m,
                            Descripcion = "Monitor Full HD 24 pulgadas",
                            Existencia = 8,
                            Precio = 300m
                        },
                        new
                        {
                            ArticuloId = 8,
                            Costo = 50m,
                            Descripcion = "Teclado Mecánico RGB",
                            Existencia = 30,
                            Precio = 100m
                        },
                        new
                        {
                            ArticuloId = 9,
                            Costo = 30m,
                            Descripcion = "Mouse Gaming",
                            Existencia = 25,
                            Precio = 70m
                        },
                        new
                        {
                            ArticuloId = 10,
                            Costo = 90m,
                            Descripcion = "Gabinete ATX con Ventilación",
                            Existencia = 10,
                            Precio = 150m
                        });
                });

            modelBuilder.Entity("MarianelaVentura_AP1_P2.Models.Combos", b =>
                {
                    b.Property<int>("ComboId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ComboId"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("Vendido")
                        .HasColumnType("bit");

                    b.HasKey("ComboId");

                    b.ToTable("Combos");
                });

            modelBuilder.Entity("MarianelaVentura_AP1_P2.Models.CombosDetalle", b =>
                {
                    b.Property<int>("DetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DetalleId"));

                    b.Property<int>("ArticuloId")
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("ComboId")
                        .HasColumnType("int");

                    b.Property<decimal>("Costo")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("DetalleId");

                    b.HasIndex("ArticuloId");

                    b.HasIndex("ComboId");

                    b.ToTable("CombosDetalle");
                });

            modelBuilder.Entity("MarianelaVentura_AP1_P2.Models.CombosDetalle", b =>
                {
                    b.HasOne("MarianelaVentura_AP1_P2.Models.Articulos", "Articulo")
                        .WithMany()
                        .HasForeignKey("ArticuloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MarianelaVentura_AP1_P2.Models.Combos", "Combo")
                        .WithMany("CombosDetalles")
                        .HasForeignKey("ComboId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Articulo");

                    b.Navigation("Combo");
                });

            modelBuilder.Entity("MarianelaVentura_AP1_P2.Models.Combos", b =>
                {
                    b.Navigation("CombosDetalles");
                });
#pragma warning restore 612, 618
        }
    }
}
