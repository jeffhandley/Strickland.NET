using NUnit.Framework;

namespace Strickland.Tests.Basics
{
    public class ValidatorFunctionFactory
    {
        [TestCase(88, 80, ExpectedResult = false)]
        [TestCase(88, 88, ExpectedResult = true)]
        [TestCase(88, 90, ExpectedResult = true)]
        public bool Validate_Min_Result_IsValid(int minValue, int value)
        {
            var minFactory = (int minValue) => (int validatedValue) => validatedValue >= minValue;
            var min = minFactory(minValue);
            var result = Validation.Validate(value, min);

            return result.IsValid;
        }

        [TestCase(88, 80, ExpectedResult = 80)]
        [TestCase(88, 88, ExpectedResult = 88)]
        [TestCase(88, 90, ExpectedResult = 90)]
        public int Validate_Min_Result_Value(int minValue, int value)
        {
            var min = (int minValue) => (int validatedValue) => validatedValue >= minValue;
            var validator = min(minValue);
            var result = Validation.Validate(value, validator);

            return result.Value;
        }
    }
}
