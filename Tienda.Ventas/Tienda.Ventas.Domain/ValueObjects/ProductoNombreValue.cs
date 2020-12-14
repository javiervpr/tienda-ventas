using System;
using System.Collections.Generic;
using System.Text;
using Tienda.SharedKernel.Core;
using Tienda.Ventas.Domain.ValueObjects.Rules;

namespace Tienda.Ventas.Domain.ValueObjects
{
    public class ProductoNombreValue : ValueObject, IComparable<ProductoNombreValue>
    {
        public string Value { get; private set; }

        public ProductoNombreValue(string value)
        {
            CheckRule(new ProductoNombreLengthRule(value));
            Value = value;
        }

        public int CompareTo(ProductoNombreValue other)
        {
            return Value.CompareTo(other.Value);
        }

        #region Conversion
        public static implicit operator string(ProductoNombreValue value) => value == null ? "" : value.Value;

        public static implicit operator ProductoNombreValue(string value) => new ProductoNombreValue(value);
        #endregion
    }
}
