using System;
using System.Collections.Generic;
using System.Text;
using Tienda.SharedKernel.Core;

namespace Tienda.SharedKernel.ValueObjects.PasswordValue.Rules
{
    public class PasswordMinLengthRule : IBusinessRule
    {
        private readonly string _value;

        public PasswordMinLengthRule(string value)
        {
            _value = value;
        }

        public string Message => "La contraseña debe tener más de 5 caracteres";

        public bool IsBroken()
        {
            return _value.Length <= 5; 
        }
    }
}
