using NUnit.Framework;
// using Strickland.Validators;

namespace Strickland.Tests.Docs
{
    public class ExtensibilityPattern
    {
        public class ExtensibleMinValidator
        {
            public struct ValidationContext
            {
                public string Culture = "en-us";
            }

            public record ValidationResult<T, V>(bool IsValid, T Value, V Validator);

            public class Min<T, P> where T : IComparisonOperators<T, T>
            {
                public record MinProperties(T MinValue, P? Properties = default);

                public T MinValue { get; init; }
                public P? Properties { get; init; }

                public Min(MinProperties properties)
                {
                    MinValue = properties.MinValue;
                    Properties = properties.Properties;
                }

                public ValidationResult<T, Min<T, P>> Validate(T value)
                {
                    var isValid = (value >= MinValue);
                    return new(isValid, value, this);
                }
            }

            public static class Min
            {
                public static Min<T, P> Of<T, P>(T minValue, P? properties) where T : IComparisonOperators<T, T>
                    => new(new(minValue, properties));
            }

            [Test]
            public void CanValidateMinWithProperties()
            {
                var validator = Min.Of(88, new { ErrorMessageFormat = "You must be traveling at least {0}mph. Your speed is {1}mph." });
                var result = validator.Validate(80);

                Assert.IsFalse(result.IsValid);
                Assert.AreEqual(88, result.Validator.MinValue);
                Assert.AreEqual(80, result.Value);
                Assert.AreEqual("You must be traveling at least {0}mph. Your speed is {1}mph.", result.Validator.Properties?.ErrorMessageFormat);
            }
        }
    }
}
