using NUnit.Framework;
using Strickland.Validators;

namespace Strickland.Tests.Validators
{
    public class RangeTests
    {
        [TestCase(88, 95)]
        [TestCase(88U, 95U)]
        [TestCase(88L, 95L)]
        [TestCase(88UL, 95UL)]
        [TestCase(88F, 95F)]
        [TestCase(88D, 95D)]
        public void SetsMinValue<T>(T minValue, T maxValue) where T : IComparisonOperators<T, T>
        {
            var Range = new Range<T>(minValue, maxValue);
            Assert.AreEqual(minValue, Range.MinValue);
        }

        [TestCase(88, 95)]
        [TestCase(88U, 95U)]
        [TestCase(88L, 95L)]
        [TestCase(88UL, 95UL)]
        [TestCase(88F, 95F)]
        [TestCase(88D, 95D)]
        public void SetsMaxValue<T>(T minValue, T maxValue) where T : IComparisonOperators<T, T>
        {
            var Range = new Range<T>(minValue, maxValue);
            Assert.AreEqual(maxValue, Range.MaxValue);
        }

        [TestCase(88, 95, 80, ExpectedResult = false)]
        [TestCase(88, 88, 88, ExpectedResult = true)]
        [TestCase(88, 95, 95, ExpectedResult = true)]
        [TestCase(88, 95, 100, ExpectedResult = false)]
        public bool Validates<T>(T minValue, T maxValue, T value) where T : IComparisonOperators<T, T>
        {
            var Range = new Range<T>(minValue, maxValue);
            return Range.IsValid(value);
        }
    }
}
