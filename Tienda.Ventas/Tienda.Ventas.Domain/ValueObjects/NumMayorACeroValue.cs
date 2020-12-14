using System;
using System.Collections.Generic;
using System.Text;
using Tienda.SharedKernel.Core;
using Tienda.Ventas.Domain.ValueObjects.Rules;

namespace Tienda.Ventas.Domain.ValueObjects
{
    public class NumMayorACeroValue : ValueObject, IComparable<NumMayorACeroValue>
    {
        public int Value { get; private set; }

        public NumMayorACeroValue(int value)
        {
            CheckRule(new NumMayorACeroRule(value));
            Value = value;
        }


        public int CompareTo(NumMayorACeroValue other)
        {
            return Value.CompareTo(other.Value);
        }
        #region Conversion
        public static implicit operator int(NumMayorACeroValue value) => value.Value;

        public static implicit operator NumMayorACeroValue(int value) => new NumMayorACeroValue(value);
        #endregion
    }
}
