using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Tienda.SharedKernel.Core;
using Tienda.SharedKernel.ValueObjects.PasswordValue.Rules;

namespace Tienda.SharedKernel.ValueObjects.PasswordValue
{
    public class PasswordValue : ValueObject, IComparable<PasswordValue>
    {
        public string Value { get; private set; }

        public PasswordValue(string value)
        {
            CheckRule(new NotNullRule<string>(value));
            CheckRule(new PasswordMinLengthRule(value));
            CheckRule(new PasswordMaxLenghtRule(value));
            Value = value;
        }

        #region Conversion

        public static implicit operator string(PasswordValue value) => value.Value == null ? "" : value.Value;

        public static implicit operator PasswordValue(string value) => new PasswordValue(value);

        #endregion

        public int CompareTo([AllowNull] PasswordValue other)
        {
            return Value.CompareTo(other.Value);
        }
    }
}
