using NUnit.Framework;

namespace Strickland.Tests.Basics
{
    public class ValidatorFunction
    {
        [TestCase(80, ExpectedResult = false)]
        [TestCase(88, ExpectedResult = true)]
        [TestCase(90, ExpectedResult = true)]
        public bool Validate_MinOf88_Result_IsValid(int value)
        {
            var min = (int validatedValue) => validatedValue >= 88;
            var result = Validation.Validate(value, min);

            return result.IsValid;
        }

        [TestCase(80, ExpectedResult = 80)]
        [TestCase(88, ExpectedResult = 88)]
        [TestCase(90, ExpectedResult = 90)]
        public int Validate_MinOf88_Result_Value(int value)
        {
            var min = (int validatedValued) => validatedValued >= 88;
            var result = Validation.Validate(value, min);

            return result.Value;
        }
    }
}
