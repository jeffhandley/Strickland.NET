using NUnit.Framework;

namespace Strickland.Tests.Basics
{
    public class ValidatorFunctionFactory
    {
        [TestCase(88, 80, ExpectedResult = false)]
        [TestCase(88, 88, ExpectedResult = true)]
        [TestCase(88, 90, ExpectedResult = true)]
        public bool Validate_Min_Result_IsValid(int testMinValue, int testValue)
        {
            var minFactory = (int minValue) => (int value) => value >= minValue;
            var min = minFactory(testMinValue);
            var result = Validation.Validate(testValue, min);

            return result.IsValid;
        }

        [TestCase(88, 80, ExpectedResult = 80)]
        [TestCase(88, 88, ExpectedResult = 88)]
        [TestCase(88, 90, ExpectedResult = 90)]
        public int Validate_Min_Result_Value(int testMinValue, int testValue)
        {
            var min = (int minValue) => (int value) => value >= minValue;
            var validator = min(testMinValue);
            var result = Validation.Validate(testValue, validator);

            return result.Value;
        }
    }
}
