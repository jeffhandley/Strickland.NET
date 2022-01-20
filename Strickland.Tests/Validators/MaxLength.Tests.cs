using NUnit.Framework;
using Strickland.Validators;

namespace Strickland.Tests.Validators
{
    public class MaxLengthTests
    {
        [TestCase(8)]
        public void SetsLimit(int limit)
        {
            var max = new MaxLength<string, char>(limit);
            Assert.AreEqual(limit, max.Limit);
        }

        [TestCase(8, "Marty", ExpectedResult = true)]
        [TestCase(8, "DocBrown", ExpectedResult = true)]
        [TestCase(8, "Strickland", ExpectedResult = false)]
        public bool ValidatesStrings(int limit, string value)
        {
            var max = new MaxLength<string, char>(limit);
            return max.IsValid(value);
        }
    }
}
