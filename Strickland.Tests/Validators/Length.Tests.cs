using NUnit.Framework;
using Strickland.Validators;

namespace Strickland.Tests.Validators
{
    public class LengthTests
    {
        [TestCase(8, 9)]
        public void SetsMinLimit(int minLimit, int maxLimit)
        {
            var max = new Length<string, char>(minLimit, maxLimit);
            Assert.AreEqual(minLimit, max.MinLimit);
        }

        [TestCase(8, 9)]
        public void SetsMaxLimit(int minLimit, int maxLimit)
        {
            var max = new Length<string, char>(minLimit, maxLimit);
            Assert.AreEqual(maxLimit, max.MaxLimit);
        }

        [TestCase(8, 9, "Marty", ExpectedResult = false)]
        [TestCase(8, 9, "DocBrown", ExpectedResult = true)]
        [TestCase(8, 9, "Strickland", ExpectedResult = false)]
        public bool ValidatesStrings(int minLimit, int maxLimit, string value)
        {
            var max = new Length<string, char>(minLimit, maxLimit);
            return max.IsValid(value);
        }
    }
}
