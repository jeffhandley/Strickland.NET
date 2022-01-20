using NUnit.Framework;
using Strickland.Validators;

namespace Strickland.Tests.Validators
{
    public class MaxTests
    {
        [TestCase(88)]
        [TestCase(88U)]
        [TestCase(88L)]
        [TestCase(88UL)]
        [TestCase(88F)]
        [TestCase(88D)]
        public void SetsLimit<T>(T limit) where T : IComparisonOperators<T, T>
        {
            var max = new Max<T>(limit);
            Assert.AreEqual(limit, max.Limit);
        }

        [TestCase(88, 80, ExpectedResult = true)]
        [TestCase(88, 88, ExpectedResult = true)]
        [TestCase(88, 90, ExpectedResult = false)]
        public bool Validates<T>(T maxValue, T value) where T : IComparisonOperators<T, T>
        {
            var max = new Max<T>(maxValue);
            return max.IsValid(value);
        }
    }
}
