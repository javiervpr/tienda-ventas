using System;
using System.Collections.Generic;
using System.Text;

namespace Tienda.Ventas.Applicacion.DTO
{
    public class ProductoDTO
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public string UrlImagen { get; set; }
        public string Categoria { get; set; }

        public ProductoDTO() {}

        public ProductoDTO(Guid id, string nombre, double precio, string urlImagen, string categoria)
        {
            Id = id;
            Nombre = nombre;
            Precio = precio;
            UrlImagen = urlImagen;
            Categoria = categoria;
        }
    }
}
