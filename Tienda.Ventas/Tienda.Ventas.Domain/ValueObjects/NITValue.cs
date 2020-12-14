using System;
using System.Collections.Generic;
using System.Text;
using Tienda.SharedKernel.Core;
using Tienda.Ventas.Domain.ValueObjects.Rules;

namespace Tienda.Ventas.Domain.ValueObjects
{
     public class NITValue : ValueObject, IComparable<NITValue>
    {
        public string Value { get; private set; }

        public NITValue(string value)
        {
            CheckRule(new NITLengthRule(value));
            Value = value;
        }


        public int CompareTo(NITValue other)
        {
            return Value.CompareTo(other.Value);
        }
        #region Conversion
        public static implicit operator string(NITValue value) => value == null ? "" : value.Value;

        public static implicit operator NITValue(string value) => new NITValue(value);
        #endregion
    }
}
