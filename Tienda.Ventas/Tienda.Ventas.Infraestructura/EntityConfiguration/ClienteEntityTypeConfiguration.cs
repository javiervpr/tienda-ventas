using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Ventas.Domain.Model.Ventas;

namespace Tienda.Ventas.Infraestructura.EntityConfiguration
{
    public class ClienteEntityTypeConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.Nombres)
                .Property(x => x.Value)
                .HasColumnName("nombres")
                .IsRequired();

            builder.OwnsOne(x => x.Apellidos)
                .Property(x => x.Value)
                .HasColumnName("apellidos")
                .IsRequired();

            builder.OwnsOne(x => x.Email)
                .Property(x => x.Value)
                .HasColumnName("email")
                .IsRequired();

            builder.OwnsOne(x => x.Password)
                .Property(x => x.Value)
                .HasColumnName("password")
                .IsRequired();
        }
    }
}
