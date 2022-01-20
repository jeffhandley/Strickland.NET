using NUnit.Framework;
using Strickland.Validators;

namespace Strickland.Tests.Validators
{
    public class MaxValidatorTests
    {
        [TestCase(88)]
        [TestCase(88U)]
        [TestCase(88L)]
        [TestCase(88UL)]
        [TestCase(88F)]
        [TestCase(88D)]
        public void SetsMax<T>(T max) where T : IComparisonOperators<T, T>
        {
            var validator = new MaxValidator<T>(max);
            Assert.AreEqual(max, validator.Max);
        }

        [TestCase(88, 80, ExpectedResult = true)]
        [TestCase(88, 88, ExpectedResult = true)]
        [TestCase(88, 90, ExpectedResult = false)]
        public bool Validates<T>(T max, T value) where T : IComparisonOperators<T, T>
        {
            var validator = new MaxValidator<T>(max);
            return validator.IsValid(value);
        }
    }
}
