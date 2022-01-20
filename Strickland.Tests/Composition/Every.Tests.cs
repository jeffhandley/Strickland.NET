using NUnit.Framework;
using Strickland.Composition;
using Strickland.Validators;

namespace Strickland.Tests.Composition
{
    public class EveryTests
    {
        [TestCase(80, ExpectedResult = false)]
        [TestCase(88, ExpectedResult = true)]
        [TestCase(95, ExpectedResult = true)]
        [TestCase(100, ExpectedResult = false)]
        public bool Validates_Array_Of_Validator_Instances(int value)
        {
            var min = new Min<int>(88);
            var max = new Max<int>(95);

            var every = new Every<int>(min, max);

            return every.IsValid(value);
        }
    }
}
