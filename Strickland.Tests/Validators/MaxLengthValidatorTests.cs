using NUnit.Framework;
using Strickland.Validators;

namespace Strickland.Tests.Validators
{
    public class MaxLengthValidatorTests
    {
        [TestCase(8)]
        public void SetsMaxLength(int maxLength)
        {
            var validator = new MaxLengthValidator<string, char>(maxLength);
            Assert.AreEqual(maxLength, validator.MaxLength);
        }

        [TestCase(8, "Marty", ExpectedResult = true)]
        [TestCase(8, "DocBrown", ExpectedResult = true)]
        [TestCase(8, "Strickland", ExpectedResult = false)]
        public bool ValidatesStrings(int maxLength, string value)
        {
            var validator = new MaxLengthValidator<string, char>(maxLength);
            return validator.IsValid(value);
        }
    }
}
