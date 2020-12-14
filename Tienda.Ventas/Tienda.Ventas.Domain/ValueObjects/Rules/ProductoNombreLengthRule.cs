﻿using System;
using System.Collections.Generic;
using System.Text;
using Tienda.SharedKernel.Core;

namespace Tienda.Ventas.Domain.ValueObjects.Rules
{
    public class ProductoNombreLengthRule : IBusinessRule
    {
        private readonly string value;

        public ProductoNombreLengthRule(string value)
        {
            this.value = value;
        }

        public string Message => "El nombre del producto debe tener menos de 150 caracteres";

        public bool IsBroken()
        {
            return value.Length > 150;
        }
    }
}
