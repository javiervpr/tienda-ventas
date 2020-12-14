using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Ventas.Domain.Model.Ventas;
using Tienda.Ventas.Infraestructura.EntityConfiguration;

namespace Tienda.Ventas.Infraestructura.Persistence
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Producto> Productos { get; private set; }
        public DbSet<Cliente> Clientes { get; private set; }
        public DbSet<Venta> Ventas { get; private set; }
        public DbSet<Factura> Facturas { get; private set; }
        public DbSet<DetalleVenta> DetalleVentas { get; private set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new ProductoEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ClienteEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new VentaEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new FacturaEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new DetalleVentaEntityTypeConfiguration());
        }
    }
}
