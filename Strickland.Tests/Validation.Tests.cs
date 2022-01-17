using NUnit.Framework;
using Strickland.Validators;

namespace Strickland.Tests
{
    public class ValidatorTests
    {
        [TestCase(88, 88, true), TestCase(88, 90, true), TestCase(88, 80, false)]
        [TestCase(88.0, 88.0, true), TestCase(88.0, 90.0, true), TestCase(88.0, 80.0, false)]
        public void IsValid<T>(T minValue, T value, bool expected) where T : IComparisonOperators<T, T>
        {
            var min = Min.Of(minValue);
            var isValid = Validation.IsValid(min, value);

            Assert.AreEqual(expected, isValid);
        }

        [TestCase(88, 88, true), TestCase(88, 90, true), TestCase(88, 80, false)]
        [TestCase(88.0, 88.0, true), TestCase(88.0, 90.0, true), TestCase(88.0, 80.0, false)]
        public void Validate<T>(T minValue, T value, bool expectedIsValid) where T : IComparisonOperators<T, T>
        {
            var min = Min.Of(minValue);
            var result = Validation.Validate(min, value);

            Assert.AreEqual(value, result.Value);
            Assert.AreEqual(expectedIsValid, result.IsValid);
        }
    }
}
