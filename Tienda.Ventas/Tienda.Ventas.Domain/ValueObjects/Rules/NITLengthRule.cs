using System;
using System.Collections.Generic;
using System.Text;
using Tienda.SharedKernel.Core;

namespace Tienda.Ventas.Domain.ValueObjects.Rules
{
    public class NITLengthRule : IBusinessRule
    {
        private readonly string value;

        public NITLengthRule(string value)
        {
            this.value = value;
        }

        public string Message => "El NIT debe tener menos de 100 caracteres";

        public bool IsBroken()
        {
            return value.Length > 100;
        }
    }
}
