using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Ventas.Domain.Model.Ventas;

namespace Tienda.Ventas.Infraestructura.EntityConfiguration
{
    public class FacturaEntityTypeConfiguration : IEntityTypeConfiguration<Factura>
    {
        public void Configure(EntityTypeBuilder<Factura> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.FechaEmision)
                .IsRequired();

            builder.OwnsOne(x => x.RazonSocial)
                .Property(x => x.Value)
                .HasColumnName("razonSocial")
                .IsRequired();

            builder.OwnsOne(x => x.NIT)
                .Property(x => x.Value)
                .HasColumnName("nit")
                .IsRequired();


        }
    }
}
