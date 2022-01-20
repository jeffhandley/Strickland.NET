using NUnit.Framework;
using Strickland.Composition;
using Strickland.Validators;

namespace Strickland.Tests.Composition
{
    public class SomeValidatorTests
    {
        [TestCase(80, ExpectedResult = true)]
        [TestCase(88, ExpectedResult = true)]
        [TestCase(95, ExpectedResult = true)]
        [TestCase(100, ExpectedResult = true)]
        public bool Validates_Array_Of_Validator_Instances(int value)
        {
            var min = new MinValidator<int>(88);
            var max = new MaxValidator<int>(95);
            var some = new SomeValidator<int>(min, max);

            return some.IsValid(value);
        }
    }
}
