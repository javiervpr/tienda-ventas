using System;
using System.Collections.Generic;
using System.Text;
using Tienda.SharedKernel.Core;
using Tienda.Ventas.Domain.ValueObjects.Rules;

namespace Tienda.Ventas.Domain.ValueObjects
{
    public class ProductoPrecioValue : ValueObject, IComparable<ProductoPrecioValue>
    {
        public double Value { get; private set; }

        public ProductoPrecioValue(double value)
        {
            CheckRule(new DoubleMayorIgualACeroRule(value));
            Value = value;
        }

        public int CompareTo(ProductoPrecioValue other)
        {
            return Value.CompareTo(other.Value);
        }

        #region Conversion
        public static implicit operator double(ProductoPrecioValue value) => value.Value;

        public static implicit operator ProductoPrecioValue(double value) => new ProductoPrecioValue(value);
        #endregion
    }
}
