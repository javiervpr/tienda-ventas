using System;
using System.Collections.Generic;
using System.Text;
using Tienda.SharedKernel.Core;

namespace Tienda.Ventas.Domain.ValueObjects.Rules
{
    public class DoubleMayorIgualACeroRule : IBusinessRule
    {
        private readonly double value;

        public DoubleMayorIgualACeroRule(double value)
        {
            this.value = value;
        }

        public string Message => "El número debe ser mayor o igual a 0";

        public bool IsBroken()
        {
            return value < 0;
        }
    }
}
