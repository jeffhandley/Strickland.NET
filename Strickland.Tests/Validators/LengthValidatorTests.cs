using NUnit.Framework;
using Strickland.Validators;

namespace Strickland.Tests.Validators
{
    public class LengthValidatorTests
    {
        [TestCase(8, 9)]
        public void SetsMinLength(int minLength, int maxLength)
        {
            var validator = new LengthValidator<string, char>(minLength, maxLength);
            Assert.AreEqual(minLength, validator.MinLength);
        }

        [TestCase(8, 9)]
        public void SetsMaxLength(int minLength, int maxLength)
        {
            var validator = new LengthValidator<string, char>(minLength, maxLength);
            Assert.AreEqual(maxLength, validator.MaxLength);
        }

        [TestCase(8, 9, "Marty", ExpectedResult = false)]
        [TestCase(8, 9, "DocBrown", ExpectedResult = true)]
        [TestCase(8, 9, "Strickland", ExpectedResult = false)]
        public bool ValidatesStrings(int minLength, int maxLength, string value)
        {
            var validator = new LengthValidator<string, char>(minLength, maxLength);
            return validator.IsValid(value);
        }
    }
}
