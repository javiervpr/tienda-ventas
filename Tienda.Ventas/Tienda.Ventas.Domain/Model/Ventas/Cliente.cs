using System;
using System.Collections.Generic;
using System.Text;
using Tienda.SharedKernel.Core;
using Tienda.SharedKernel.ValueObjects;
using Tienda.SharedKernel.ValueObjects.EmailValue;
using Tienda.SharedKernel.ValueObjects.PasswordValue;

namespace Tienda.Ventas.Domain.Model.Ventas
{
    public class Cliente: Entity
    {
        public Guid Id { get; private set; }
        public PersonNameValue Nombres { get; private set; }
        public PersonNameValue Apellidos { get; private set; }
        public EmailValue Email { get; private set; }
        public PasswordValue Password { get; private set; }

        public Cliente( string nombres, string apellidos, string email, string password)
        {
            Id = Guid.NewGuid();
            Nombres = nombres;
            Apellidos = apellidos;
            Email = email;
            Password = password;
        }

        protected Cliente() { }

        public void ActualizarClientes() { }
    }
}
