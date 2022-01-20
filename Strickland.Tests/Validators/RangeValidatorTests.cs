using NUnit.Framework;
using Strickland.Validators;

namespace Strickland.Tests.Validators
{
    public class RangeValidatorTests
    {
        [TestCase(88, 95)]
        [TestCase(88U, 95U)]
        [TestCase(88L, 95L)]
        [TestCase(88UL, 95UL)]
        [TestCase(88F, 95F)]
        [TestCase(88D, 95D)]
        public void SetsMin<T>(T min, T max) where T : IComparisonOperators<T, T>
        {
            var validator = new RangeValidator<T>(min, max);
            Assert.AreEqual(min, validator.Min);
        }

        [TestCase(88, 95)]
        [TestCase(88U, 95U)]
        [TestCase(88L, 95L)]
        [TestCase(88UL, 95UL)]
        [TestCase(88F, 95F)]
        [TestCase(88D, 95D)]
        public void SetsMax<T>(T min, T max) where T : IComparisonOperators<T, T>
        {
            var validator = new RangeValidator<T>(min, max);
            Assert.AreEqual(max, validator.Max);
        }

        [TestCase(88, 95, 80, ExpectedResult = false)]
        [TestCase(88, 88, 88, ExpectedResult = true)]
        [TestCase(88, 95, 95, ExpectedResult = true)]
        [TestCase(88, 95, 100, ExpectedResult = false)]
        public bool Validates<T>(T min, T max, T value) where T : IComparisonOperators<T, T>
        {
            var validator = new RangeValidator<T>(min, max);
            return validator.IsValid(value);
        }
    }
}
