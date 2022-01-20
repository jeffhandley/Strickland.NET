using NUnit.Framework;

namespace Strickland.Tests.Basics
{
    public class GenericValidatorFunction
    {
        [TestCase(88, 80, ExpectedResult = false)]
        [TestCase(88, 88, ExpectedResult = true)]
        [TestCase(88, 90, ExpectedResult = true)]
        public bool Validate_Min_Result_IsValid<T>(T minValue, T value) where T : IComparisonOperators<T, T>
        {
            var min = (T validatedValue) => validatedValue >= minValue;
            var result = Validation.Validate(value, min);

            return result.IsValid;
        }

        [TestCase(88, 80, ExpectedResult = 80)]
        [TestCase(88, 88, ExpectedResult = 88)]
        [TestCase(88, 90, ExpectedResult = 90)]
        public T Validate_Min_Result_Value<T>(T minValue, T value) where T : IComparisonOperators<T, T>
        {
            var min = (T validatedValue) => validatedValue >= minValue;
            var result = Validation.Validate(value, min);

            return result.Value;
        }
    }
}
