using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Tienda.Ventas.Domain.Model.Ventas;

namespace Tienda.Ventas.Infraestructura.EntityConfiguration
{
    public class ProductoEntityTypeConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.Nombre)
                .Property(x => x.Value)
                .HasColumnName("nombre")
                .IsRequired();

            builder.OwnsOne(x => x.Precio)
                .Property(x => x.Value)
                .HasColumnName("precio")
                .IsRequired()
                .HasColumnType("decimal(20,12)");

            builder.OwnsOne(x => x.Categoria)
                .Property(x => x.Value)
                .HasColumnName("categoria");


            builder.Property(x => x.UrlImagen)
                .HasColumnName("urlImagen");
        }
    }
}
