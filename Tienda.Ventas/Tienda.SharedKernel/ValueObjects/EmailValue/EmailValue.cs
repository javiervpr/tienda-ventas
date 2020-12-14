using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using Tienda.SharedKernel.Core;
using Tienda.SharedKernel.ValueObjects.EmailValue.Rules;

namespace Tienda.SharedKernel.ValueObjects.EmailValue
{
    public class EmailValue : ValueObject, IComparable<EmailValue>
    {
        public string Value { get; private set; }

        public EmailValue(string value)
        {
            CheckRule(new NotNullRule<string>(value));
            CheckRule(new EmailRule(value));
            Value = value;
        }

        public int CompareTo([AllowNull] EmailValue other)
        {
            return Value.CompareTo(other.Value);
        }

        #region Conversion

        public static implicit operator string(EmailValue value) => value.Value == null ? "" : value.Value;

        public static implicit operator EmailValue(string value) => new EmailValue(value);

        #endregion
    }
}
