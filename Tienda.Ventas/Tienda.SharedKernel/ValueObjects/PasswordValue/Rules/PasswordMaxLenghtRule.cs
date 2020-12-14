using System;
using System.Collections.Generic;
using System.Text;
using Tienda.SharedKernel.Core;

namespace Tienda.SharedKernel.ValueObjects.PasswordValue.Rules
{
    public class PasswordMaxLenghtRule : IBusinessRule
    {
        private readonly string _value;

        public PasswordMaxLenghtRule(string value)
        {
            _value = value;
        }

        public string Message => "La contraseña debe tener menos de 35 caracteres";

        public bool IsBroken()
        {
            return _value.Length >= 35;
        }
    }
}
