using NUnit.Framework;

namespace Strickland.Validators.Min.Tests
{
    public class MinTests
    {
        [Test]
        public void Equals_MinValue_IsValid()
        {
            var min = new Min<int>(88);
            var result = min.Validate(88);

            Assert.IsTrue(result);
        }

        [Test]
        public void GreaterThan_MinValue_IsValid()
        {
            var min = new Min<int>(88);
            var result = min.Validate(90);

            Assert.IsTrue(result);
        }

        [Test]
        public void LessThan_MinValue_IsNotValid()
        {
            var min = new Min<int>(88);
            var result = min.Validate(80);

            Assert.IsFalse(result);
        }
    }
}