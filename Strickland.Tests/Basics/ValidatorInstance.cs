using NUnit.Framework;
using Strickland.Validators;

namespace Strickland.Tests.Basics
{
    public class ValidatorInstance
    {
        public class Min : IValidator<int>
        {
            public int MinValue { get; init; }
            public Min(int minValue) => MinValue = minValue;
            public bool IsValid(int value) => value >= MinValue;
        }

        [TestCase(88, 80, ExpectedResult = false)]
        [TestCase(88, 88, ExpectedResult = true)]
        [TestCase(88, 90, ExpectedResult = true)]
        public bool Validate_Min_Result_IsValid(int testMinValue, int testValue)
        {
            var validator = new Min(testMinValue);
            var result = Validation.Validate(testValue, validator);

            return result.IsValid;
        }

        [TestCase(88, 80, ExpectedResult = 80)]
        [TestCase(88, 88, ExpectedResult = 88)]
        [TestCase(88, 90, ExpectedResult = 90)]
        public int Validate_Min_Result_Value(int testMinValue, int testValue)
        {
            var validator = new Min(testMinValue);
            var result = Validation.Validate(testValue, validator);

            return result.Value;
        }

        [TestCase(88, 80, ExpectedResult = 88)]
        [TestCase(88, 88, ExpectedResult = 88)]
        [TestCase(88, 90, ExpectedResult = 88)]
        public int Validate_Min_Result_MinValue(int testMinValue, int testValue)
        {
            var validator = new Min(testMinValue);
            var result = Validation.Validate(testValue, validator);

            return result.Validator.MinValue;
        }
    }
}
