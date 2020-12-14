using System;
using System.Collections.Generic;
using System.Text;

namespace Tienda.Ventas.Applicacion.DTO
{
    public class ClienteDTO
    {
        public Guid Id { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Email { get; set; }
        //public string Password { get;  set; }

        public ClienteDTO() { }

        public ClienteDTO(Guid id, string nombres, string apellidos, string email)
        {
            Id = id;
            Nombres = nombres;
            Apellidos = apellidos;
            Email = email;
        }

    }
}
