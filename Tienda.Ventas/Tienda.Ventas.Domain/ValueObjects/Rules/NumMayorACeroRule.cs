using System;
using System.Collections.Generic;
using System.Text;
using Tienda.SharedKernel.Core;

namespace Tienda.Ventas.Domain.ValueObjects.Rules
{
    public class NumMayorACeroRule: IBusinessRule
    {
        private readonly int value;

        public NumMayorACeroRule(int value)
        {
            this.value = value;
        }

        public string Message => "El número debe ser mayor a 0";

        public bool IsBroken()
        {
            return value <= 0;
        }
    }
}
