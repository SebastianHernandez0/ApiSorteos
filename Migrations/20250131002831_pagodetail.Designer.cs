﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TechLottery.Models;

#nullable disable

namespace TechLottery.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20250131002831_pagodetail")]
    partial class pagodetail
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TechLottery.Models.Boleto", b =>
                {
                    b.Property<int>("BoletoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BoletoId"));

                    b.Property<DateTime>("FechaCompra")
                        .HasColumnType("datetime2");

                    b.Property<string>("NumeroBoleto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SorteoId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("BoletoId");

                    b.HasIndex("SorteoId");

                    b.ToTable("Boletos");
                });

            modelBuilder.Entity("TechLottery.Models.HistorialSorteo", b =>
                {
                    b.Property<int>("HistorialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HistorialId"));

                    b.Property<DateTime>("FechaGanado")
                        .HasColumnType("datetime2");

                    b.Property<int>("GanadorId")
                        .HasColumnType("int");

                    b.Property<int>("SorteoId")
                        .HasColumnType("int");

                    b.HasKey("HistorialId");

                    b.HasIndex("GanadorId");

                    b.HasIndex("SorteoId");

                    b.ToTable("HistorialSorteos");
                });

            modelBuilder.Entity("TechLottery.Models.Pago", b =>
                {
                    b.Property<int>("PagoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PagoId"));

                    b.Property<string>("EstadoPago")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaPago")
                        .HasColumnType("datetime2");

                    b.Property<int>("Monto")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PagoId");

                    b.HasIndex("UserId");

                    b.ToTable("Pagos");
                });

            modelBuilder.Entity("TechLottery.Models.PagoDetalle", b =>
                {
                    b.Property<int>("PagoDetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PagoDetalleId"));

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("Monto")
                        .HasColumnType("int");

                    b.Property<int>("PagoId")
                        .HasColumnType("int");

                    b.Property<int>("SorteoId")
                        .HasColumnType("int");

                    b.HasKey("PagoDetalleId");

                    b.HasIndex("PagoId");

                    b.HasIndex("SorteoId");

                    b.ToTable("PagoDetalles");
                });

            modelBuilder.Entity("TechLottery.Models.Sorteo", b =>
                {
                    b.Property<int>("SorteoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SorteoId"));

                    b.Property<int>("BoletosTotales")
                        .HasColumnType("int");

                    b.Property<int>("BoletosVendidos")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<string>("Imagen")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PrecioBoletos")
                        .HasColumnType("int");

                    b.HasKey("SorteoId");

                    b.ToTable("Sorteos");
                });

            modelBuilder.Entity("TechLottery.Models.Usuario", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<string>("Instagram")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("TechLottery.Models.Boleto", b =>
                {
                    b.HasOne("TechLottery.Models.Sorteo", "Sorteo")
                        .WithMany()
                        .HasForeignKey("SorteoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sorteo");
                });

            modelBuilder.Entity("TechLottery.Models.HistorialSorteo", b =>
                {
                    b.HasOne("TechLottery.Models.Usuario", "Ganador")
                        .WithMany()
                        .HasForeignKey("GanadorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechLottery.Models.Sorteo", "Sorteo")
                        .WithMany()
                        .HasForeignKey("SorteoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ganador");

                    b.Navigation("Sorteo");
                });

            modelBuilder.Entity("TechLottery.Models.Pago", b =>
                {
                    b.HasOne("TechLottery.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Usuario");
                });

            modelBuilder.Entity("TechLottery.Models.PagoDetalle", b =>
                {
                    b.HasOne("TechLottery.Models.Pago", "Pago")
                        .WithMany()
                        .HasForeignKey("PagoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TechLottery.Models.Sorteo", "Sorteo")
                        .WithMany()
                        .HasForeignKey("SorteoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pago");

                    b.Navigation("Sorteo");
                });
#pragma warning restore 612, 618
        }
    }
}
