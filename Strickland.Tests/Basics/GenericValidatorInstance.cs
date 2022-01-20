using NUnit.Framework;
using Strickland.Validators;

namespace Strickland.Tests.Basics
{
    public class GenericValidatorInstance
    {
        public class MinValidator<T> : IValidatorFunction<T> where T : IComparisonOperators<T, T>
        {
            public T Min { get; init; }
            public MinValidator(T min) => Min = min;
            public bool IsValid(T value) => value >= Min;
        }

        [TestCase(88, 80, ExpectedResult = false)]
        [TestCase(88, 88, ExpectedResult = true)]
        [TestCase(88, 90, ExpectedResult = true)]
        public bool Validate_Min_Result_IsValid<T>(T minValue, T value) where T : IComparisonOperators<T, T>
        {
            var validator = new MinValidator<T>(minValue);
            var result = Validation.Validate(value, validator);

            return result.IsValid;
        }

        [TestCase(88, 80, ExpectedResult = 80)]
        [TestCase(88, 88, ExpectedResult = 88)]
        [TestCase(88, 90, ExpectedResult = 90)]
        public T Validate_Min_Result_Value<T>(T minValue, T value) where T : IComparisonOperators<T, T>
        {
            var validator = new MinValidator<T>(minValue);
            var result = Validation.Validate(value, validator);

            return result.Value;
        }

        [TestCase(88, 80, ExpectedResult = 88)]
        [TestCase(88, 88, ExpectedResult = 88)]
        [TestCase(88, 90, ExpectedResult = 88)]
        public T Validate_Min_Result_Min<T>(T minValue, T value) where T : IComparisonOperators<T, T>
        {
            var validator = new MinValidator<T>(minValue);
            var result = Validation.Validate(value, validator);

            return result.Validator.Min;
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
            public bool Validate_Min_Result_IsValid<T>(T minValue, T value) where T : IComparisonOperators<T, T>
            {
                var validator = new MinValidator<T>(minValue);
                var result = Validation.Validate(value, validator);

                return result.IsValid;
            }

            [TestCase(88, 80, ExpectedResult = 80)]
            [TestCase(88, 88, ExpectedResult = 88)]
            [TestCase(88, 90, ExpectedResult = 90)]
            public T Validate_Min_Result_Value<T>(T minValue, T value) where T : IComparisonOperators<T, T>
            {
                var validator = new MinValidator<T>(minValue);
                var result = Validation.Validate(value, validator);

                return result.Value;
            }

            [TestCase(88, 80, ExpectedResult = 88)]
            [TestCase(88, 88, ExpectedResult = 88)]
            [TestCase(88, 90, ExpectedResult = 88)]
            public T Validate_Min_Result_Min<T>(T minValue, T value) where T : IComparisonOperators<T, T>
            {
                var validator = new MinValidator<T>(minValue);
                var result = Validation.Validate(value, validator);

                return result.Validator.Min;
            }
        }
    }
}
