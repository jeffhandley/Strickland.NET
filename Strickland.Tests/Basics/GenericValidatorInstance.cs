using NUnit.Framework;
using Strickland.Validators;

namespace Strickland.Tests.Basics
{
    public class GenericValidatorInstance
    {
        public class Min<T> : IValidator<T> where T : IComparisonOperators<T, T>
        {
            public T MinValue { get; init; }
            public Min(T minValue) => MinValue = minValue;
            public bool IsValid(T value) => value >= MinValue;
        }

        [TestCase(88, 80, ExpectedResult = false)]
        [TestCase(88, 88, ExpectedResult = true)]
        [TestCase(88, 90, ExpectedResult = true)]
        public bool Validate_Min_Result_IsValid<T>(T testMinValue, T testValue) where T : IComparisonOperators<T, T>
        {
            var validator = new Min<T>(testMinValue);
            var result = Strickland.Validation.Validate(testValue, validator);
            return result.IsValid;
        }

        [TestCase(88, 80, ExpectedResult = 80)]
        [TestCase(88, 88, ExpectedResult = 88)]
        [TestCase(88, 90, ExpectedResult = 90)]
        public T Validate_Min_Result_Value<T>(T testMinValue, T testValue) where T : IComparisonOperators<T, T>
        {
            var validator = new Min<T>(testMinValue);
            var result = Strickland.Validation.Validate(testValue, validator);
            return result.Value;
        }

        [TestCase(88, 80, ExpectedResult = 88)]
        [TestCase(88, 88, ExpectedResult = 88)]
        [TestCase(88, 90, ExpectedResult = 88)]
        public T Validate_Min_Result_MinValue<T>(T testMinValue, T testValue) where T : IComparisonOperators<T, T>
        {
            var validator = new Min<T>(testMinValue);
            var result = Strickland.Validation.Validate(testValue, validator);
            return result.Validator.MinValue;
        }

        /// <summary>
        /// Illustrates an approach for working around the language limitation
        /// that disallows generic type argument inference on constructors.
        /// </summary>
        public class Shorthand
        {
            [TestCase(88, 80, ExpectedResult = false)]
            [TestCase(88, 88, ExpectedResult = true)]
            [TestCase(88, 90, ExpectedResult = true)]
            public bool Validate_Min_Result_IsValid<T>(T testMinValue, T testValue) where T : IComparisonOperators<T, T>
            {
                var validator = new Min<T>(testMinValue);
                var result = Strickland.Validation.Validate(testValue, validator);
                return result.IsValid;
            }

            [TestCase(88, 80, ExpectedResult = 80)]
            [TestCase(88, 88, ExpectedResult = 88)]
            [TestCase(88, 90, ExpectedResult = 90)]
            public T Validate_Min_Result_Value<T>(T testMinValue, T testValue) where T : IComparisonOperators<T, T>
            {
                var validator = new Min<T>(testMinValue);
                var result = Strickland.Validation.Validate(testValue, validator);
                return result.Value;
            }

            [TestCase(88, 80, ExpectedResult = 88)]
            [TestCase(88, 88, ExpectedResult = 88)]
            [TestCase(88, 90, ExpectedResult = 88)]
            public T Validate_Min_Result_MinValue<T>(T testMinValue, T testValue) where T : IComparisonOperators<T, T>
            {
                var validator = new Min<T>(testMinValue);
                var result = Strickland.Validation.Validate(testValue, validator);
                return result.Validator.MinValue;
            }
        }
    }
}
