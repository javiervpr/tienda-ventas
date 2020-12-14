using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Tienda.SharedKernel.Core;
using Tienda.Ventas.Domain.ValueObjects.Rules;

namespace Tienda.Ventas.Domain.ValueObjects
{
    public class NombreCategoriaValue : ValueObject, IComparable<NombreCategoriaValue>
    {
        public string Value { get; private set; }

        public NombreCategoriaValue(string value)
        {
            CheckRule(new NombreCategoriaLengthRule(value));
            Value = value;
        }

        public int CompareTo([AllowNull] NombreCategoriaValue other)
        {
            return Value.CompareTo(other.Value);
        }

        #region Conversion
        public static implicit operator string(NombreCategoriaValue value) => value == null ? "" : value.Value;

        public static implicit operator NombreCategoriaValue(string value) => new NombreCategoriaValue(value);
        #endregion
    }
}
