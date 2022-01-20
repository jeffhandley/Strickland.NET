using NUnit.Framework;
using Strickland.Validators;

namespace Strickland.Tests.Validators
{
    public class MinValidatorTests
    {
        [TestCase(88)]
        [TestCase(88U)]
        [TestCase(88L)]
        [TestCase(88UL)]
        [TestCase(88F)]
        [TestCase(88D)]
        public void SetsMin<T>(T min) where T : IComparisonOperators<T, T>
        {
            var validator = new MinValidator<T>(min);
            Assert.AreEqual(min, validator.Min);
        }

        [TestCase(88, 80, ExpectedResult = false)]
        [TestCase(88, 88, ExpectedResult = true)]
        [TestCase(88, 90, ExpectedResult = true)]
        public bool Validates<T>(T min, T value) where T : IComparisonOperators<T, T>
        {
            var validator = new MinValidator<T>(min);
            return validator.IsValid(value);
        }
    }
}
