﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tienda.Ventas.Infraestructura.Persistence;

namespace Tienda.Ventas.Infraestructura.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20201211034225_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("Tienda.Ventas.Domain.Model.Ventas.Cliente", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Tienda.Ventas.Domain.Model.Ventas.DetalleVenta", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProductoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("VentaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProductoId");

                    b.HasIndex("VentaId");

                    b.ToTable("DetalleVentas");
                });

            modelBuilder.Entity("Tienda.Ventas.Domain.Model.Ventas.Factura", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("FechaEmision")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("VentaId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("VentaId");

                    b.ToTable("Facturas");
                });

            modelBuilder.Entity("Tienda.Ventas.Domain.Model.Ventas.Producto", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("Tienda.Ventas.Domain.Model.Ventas.Venta", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClienteId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("EstadoVenta")
                        .HasColumnType("int")
                        .HasColumnName("estado");

                    b.Property<DateTime?>("FechaAnulacion")
                        .HasColumnType("datetime2")
                        .HasColumnName("fechaAnulacion");

                    b.Property<DateTime?>("FechaCancelacion")
                        .HasColumnType("datetime2")
                        .HasColumnName("fechaCancelacion");

                    b.Property<DateTime>("FechaCreacion")
                        .HasColumnType("datetime2")
                        .HasColumnName("fechaCreacion");

                    b.Property<DateTime?>("FechaFinalizacion")
                        .HasColumnType("datetime2")
                        .HasColumnName("fechaFinalizacion");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Ventas");
                });

            modelBuilder.Entity("Tienda.Ventas.Domain.Model.Ventas.Cliente", b =>
                {
                    b.OwnsOne("Tienda.SharedKernel.ValueObjects.PersonNameValue", "Apellidos", b1 =>
                        {
                            b1.Property<Guid>("ClienteId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("apellidos");

                            b1.HasKey("ClienteId");

                            b1.ToTable("Clientes");

                            b1.WithOwner()
                                .HasForeignKey("ClienteId");
                        });

                    b.OwnsOne("Tienda.SharedKernel.ValueObjects.PersonNameValue", "Nombres", b1 =>
                        {
                            b1.Property<Guid>("ClienteId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("nombres");

                            b1.HasKey("ClienteId");

                            b1.ToTable("Clientes");

                            b1.WithOwner()
                                .HasForeignKey("ClienteId");
                        });

                    b.Navigation("Apellidos");

                    b.Navigation("Nombres");
                });

            modelBuilder.Entity("Tienda.Ventas.Domain.Model.Ventas.DetalleVenta", b =>
                {
                    b.HasOne("Tienda.Ventas.Domain.Model.Ventas.Producto", "Producto")
                        .WithMany()
                        .HasForeignKey("ProductoId");

                    b.HasOne("Tienda.Ventas.Domain.Model.Ventas.Venta", "Venta")
                        .WithMany()
                        .HasForeignKey("VentaId");

                    b.OwnsOne("Tienda.Ventas.Domain.ValueObjects.DoubleMayorIgualACeroValue", "Precio", b1 =>
                        {
                            b1.Property<Guid>("DetalleVentaId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<double>("Value")
                                .HasColumnType("float")
                                .HasColumnName("precio");

                            b1.HasKey("DetalleVentaId");

                            b1.ToTable("DetalleVentas");

                            b1.WithOwner()
                                .HasForeignKey("DetalleVentaId");
                        });

                    b.OwnsOne("Tienda.Ventas.Domain.ValueObjects.DoubleMayorIgualACeroValue", "Subtotal", b1 =>
                        {
                            b1.Property<Guid>("DetalleVentaId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<double>("Value")
                                .HasColumnType("float")
                                .HasColumnName("subtotal");

                            b1.HasKey("DetalleVentaId");

                            b1.ToTable("DetalleVentas");

                            b1.WithOwner()
                                .HasForeignKey("DetalleVentaId");
                        });

                    b.OwnsOne("Tienda.Ventas.Domain.ValueObjects.NumMayorACeroValue", "Cantidad", b1 =>
                        {
                            b1.Property<Guid>("DetalleVentaId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Value")
                                .HasColumnType("int")
                                .HasColumnName("cantidad");

                            b1.HasKey("DetalleVentaId");

                            b1.ToTable("DetalleVentas");

                            b1.WithOwner()
                                .HasForeignKey("DetalleVentaId");
                        });

                    b.Navigation("Cantidad");

                    b.Navigation("Precio");

                    b.Navigation("Producto");

                    b.Navigation("Subtotal");

                    b.Navigation("Venta");
                });

            modelBuilder.Entity("Tienda.Ventas.Domain.Model.Ventas.Factura", b =>
                {
                    b.HasOne("Tienda.Ventas.Domain.Model.Ventas.Venta", "Venta")
                        .WithMany()
                        .HasForeignKey("VentaId");

                    b.OwnsOne("Tienda.Ventas.Domain.ValueObjects.NITValue", "NIT", b1 =>
                        {
                            b1.Property<Guid>("FacturaId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("nit");

                            b1.HasKey("FacturaId");

                            b1.ToTable("Facturas");

                            b1.WithOwner()
                                .HasForeignKey("FacturaId");
                        });

                    b.OwnsOne("Tienda.Ventas.Domain.ValueObjects.RazonSocialValue", "RazonSocial", b1 =>
                        {
                            b1.Property<Guid>("FacturaId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("razonSocial");

                            b1.HasKey("FacturaId");

                            b1.ToTable("Facturas");

                            b1.WithOwner()
                                .HasForeignKey("FacturaId");
                        });

                    b.Navigation("NIT");

                    b.Navigation("RazonSocial");

                    b.Navigation("Venta");
                });

            modelBuilder.Entity("Tienda.Ventas.Domain.Model.Ventas.Producto", b =>
                {
                    b.OwnsOne("Tienda.Ventas.Domain.ValueObjects.ProductoNombreValue", "Nombre", b1 =>
                        {
                            b1.Property<Guid>("ProductoId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("nombre");

                            b1.HasKey("ProductoId");

                            b1.ToTable("Productos");

                            b1.WithOwner()
                                .HasForeignKey("ProductoId");
                        });

                    b.OwnsOne("Tienda.Ventas.Domain.ValueObjects.ProductoPrecioValue", "Precio", b1 =>
                        {
                            b1.Property<Guid>("ProductoId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<decimal>("Value")
                                .HasColumnType("decimal(20,12)")
                                .HasColumnName("precio");

                            b1.HasKey("ProductoId");

                            b1.ToTable("Productos");

                            b1.WithOwner()
                                .HasForeignKey("ProductoId");
                        });

                    b.Navigation("Nombre");

                    b.Navigation("Precio");
                });

            modelBuilder.Entity("Tienda.Ventas.Domain.Model.Ventas.Venta", b =>
                {
                    b.HasOne("Tienda.Ventas.Domain.Model.Ventas.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId");

                    b.Navigation("Cliente");
                });
#pragma warning restore 612, 618
        }
    }
}
