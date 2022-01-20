using NUnit.Framework;
using Strickland.Validators;

namespace Strickland.Tests.Validators
{
    public class MinLengthTests
    {
        [TestCase(8)]
        public void SetsLimit(int limit)
        {
            var min = new MinLengthValidator<string, char>(limit);
            Assert.AreEqual(limit, min.MinLength);
        }

        [TestCase(8, "Marty", ExpectedResult = false)]
        [TestCase(8, "DocBrown", ExpectedResult = true)]
        [TestCase(8, "Strickland", ExpectedResult = true)]
        public bool ValidatesStrings(int limit, string value)
        {
            var min = new MinLengthValidator<string, char>(limit);
            return min.IsValid(value);
        }
    }
}
