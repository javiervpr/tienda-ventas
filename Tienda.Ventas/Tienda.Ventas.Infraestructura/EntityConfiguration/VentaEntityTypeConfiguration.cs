using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Ventas.Domain.Model.Ventas;

namespace Tienda.Ventas.Infraestructura.EntityConfiguration
{
    public class VentaEntityTypeConfiguration : IEntityTypeConfiguration<Venta>
    {
        public void Configure(EntityTypeBuilder<Venta> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.EstadoVenta)
                .HasColumnName("estado")
                .IsRequired();

            builder.Property(x => x.FechaCreacion)
                .HasColumnName("fechaCreacion")
                .IsRequired();

            builder.Property(x => x.FechaFinalizacion)
                .HasColumnName("fechaFinalizacion");


            builder.Property(x => x.FechaAnulacion)
                .HasColumnName("fechaAnulacion");

            builder.Ignore(x => x.Factura);
            builder.Ignore(x => x.DetalleVenta);
            /*
                public Cliente Cliente { get; private set; }
            */
        }
    }
}
