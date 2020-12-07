using System;
using System.Collections.Generic;
using System.Text;
using Tienda.SharedKernel.Core;

namespace Tienda.Ventas.Domain.Model.Ventas
{
    public class Cliente: Entity
    {
        public Guid Id { get; private set; }
        public string Nombres { get; private set; }
        public string Apellidos { get; private set; }

        public Cliente( string nombres, string apellidos)
        {
            Id = Guid.NewGuid();
            Nombres = nombres;
            Apellidos = apellidos;
        }

        protected Cliente() { }

        public void ActualizarClientes() { }
    }
}
