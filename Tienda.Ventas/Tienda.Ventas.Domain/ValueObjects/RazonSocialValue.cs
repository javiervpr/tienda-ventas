using System;
using System.Collections.Generic;
using System.Text;
using Tienda.SharedKernel.Core;
using Tienda.Ventas.Domain.ValueObjects.Rules;

namespace Tienda.Ventas.Domain.ValueObjects
{
    public class RazonSocialValue : ValueObject, IComparable<RazonSocialValue>
    {
        public string Value { get; private set; }

        public RazonSocialValue(string value)
        {
            CheckRule(new RazonSocialLengthRule(value));
            Value = value;
        }


        public int CompareTo(RazonSocialValue other)
        {
            return Value.CompareTo(other.Value);
        }
        #region Conversion
        public static implicit operator string(RazonSocialValue value) => value == null ? "" : value.Value;

        public static implicit operator RazonSocialValue(string value) => new RazonSocialValue(value);
        #endregion
    }
}
