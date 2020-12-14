using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Tienda.SharedKernel.Core;

namespace Tienda.SharedKernel.ValueObjects.EmailValue.Rules
{
    public class EmailRule : IBusinessRule
    {
        private readonly string _value;

        public EmailRule(string value)
        {
            _value = value;
        }

        public string Message => "El email no es valido";

        public bool IsBroken()
        {
            return !Regex.IsMatch(_value, "^([\\w\\.\\-]+)@([\\w\\-]+)((\\.(\\w){2,3})+)$");
        }
    }
}
