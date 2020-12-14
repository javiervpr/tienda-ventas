using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Ventas.Domain.Model.Ventas;

namespace Tienda.Ventas.Infraestructura.EntityConfiguration
{
    public class DetalleVentaEntityTypeConfiguration : IEntityTypeConfiguration<DetalleVenta>
    {
        public void Configure(EntityTypeBuilder<DetalleVenta> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.Cantidad)
                .Property(x => x.Value)
                .HasColumnName("cantidad")
                .IsRequired();

            builder.OwnsOne(x => x.Subtotal)
                .Property(x => x.Value)
                .HasColumnName("subtotal")
                .IsRequired();

            builder.OwnsOne(x => x.Precio)
                .Property(x => x.Value)
                .HasColumnName("precio")
                .IsRequired();
            /*
            public Venta Venta { get; private set; }
            public Producto Producto { get; private set; }
             */
        }
    }
}
