using System;
using System.Collections.Generic;
using System.Text;
using Tienda.SharedKernel.Core;
using Tienda.Ventas.Domain.ValueObjects;

namespace Tienda.Ventas.Domain.Model.Ventas
{
    public class Producto: Entity
    {
        public Guid Id { get; private set; }
        public ProductoNombreValue Nombre { get; private set; }
        public ProductoPrecioValue Precio { get; private set; }
        public NombreCategoriaValue Categoria { get; private set; }
        public string UrlImagen { get; private set; }
        public Producto(string nombre, double precio, string urlImagen, string categoria)
        {
            Id = Guid.NewGuid();
            Nombre = nombre;
            Precio = precio;
            UrlImagen = urlImagen;
            Categoria = categoria;
        }

        protected Producto() {}

        public void ActualizarProductos () { }
    }
}
