using System;
using Tienda.SharedKernel.Core;
using Tienda.Ventas.Domain.ValueObjects.Rules;

namespace Tienda.Ventas.Domain.ValueObjects
{
    public class DoubleMayorIgualACeroValue : ValueObject, IComparable<DoubleMayorIgualACeroValue>
    {
        public double Value { get; private set; }

        public DoubleMayorIgualACeroValue(double value)
        {
            CheckRule(new DoubleMayorIgualACeroRule(value));
            Value = value;
        }


        public int CompareTo(DoubleMayorIgualACeroValue other)
        {
            return Value.CompareTo(other.Value);
        }
        #region Conversion
        public static implicit operator double(DoubleMayorIgualACeroValue value) => value.Value;

        public static implicit operator DoubleMayorIgualACeroValue(double value) => new DoubleMayorIgualACeroValue(value);
        #endregion
    }
}
