using NUnit.Framework;
using Strickland.Validators;

namespace Strickland.Tests.Basics
{
    public class ValidatorInstance
    {
        public class MinValidator : IValidatorFunction<int>
        {
            public int Min { get; init; }
            public MinValidator(int min) => Min = min;
            public bool IsValid(int value) => value >= Min;
        }

        [TestCase(88, 80, ExpectedResult = false)]
        [TestCase(88, 88, ExpectedResult = true)]
        [TestCase(88, 90, ExpectedResult = true)]
        public bool Validate_Min_Result_IsValid(int minValue, int value)
        {
            var validator = new MinValidator(minValue);
            var result = Validation.Validate(value, validator);

            return result.IsValid;
        }

        [TestCase(88, 80, ExpectedResult = 80)]
        [TestCase(88, 88, ExpectedResult = 88)]
        [TestCase(88, 90, ExpectedResult = 90)]
        public int Validate_Min_Result_Value(int minValue, int value)
        {
            var validator = new MinValidator(minValue);
            var result = Validation.Validate(value, validator);

            return result.Value;
        }

        [TestCase(88, 80, ExpectedResult = 88)]
        [TestCase(88, 88, ExpectedResult = 88)]
        [TestCase(88, 90, ExpectedResult = 88)]
        public int Validate_Min_Result_MinValue(int minValue, int value)
        {
            var validator = new MinValidator(minValue);
            var result = Validation.Validate(value, validator);

            return result.Validator.Min;
        }
    }
}
