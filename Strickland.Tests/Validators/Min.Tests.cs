using NUnit.Framework;

namespace Strickland.Validators.Tests
{
    public class MinTests
    {
        [Test]
        public void Equals_MinValue_IsValid()
        {
            var min = Min.Of(88);
            var result = min.Validate(88);

            Assert.IsTrue(result);
        }

        [Test]
        public void GreaterThan_MinValue_IsValid()
        {
            var min = Min.Of(88);
            var result = min.Validate(90);

            Assert.IsTrue(result);
        }

        [Test]
        public void LessThan_MinValue_IsNotValid()
        {
            var min = Min.Of(88);
            var result = min.Validate(80);

            Assert.IsFalse(result);
        }

        public class UsingFuncWithoutValidationContext
        {
            [Test]
            public void Equals_MinValue_IsValid()
            {
                var min = Min.Of(() => 88);
                var result = min.Validate(88);

                Assert.IsTrue(result);
            }

            [Test]
            public void GreaterThan_MinValue_IsValid()
            {
                var min = Min.Of(() => 88);
                var result = min.Validate(90);

                Assert.IsTrue(result);
            }

            [Test]
            public void LessThan_MinValue_IsNotValid()
            {
                var min = Min.Of(() => 88);
                var result = min.Validate(80);

                Assert.IsFalse(result);
            }
        }

        public class UsingFuncWithValidationContext
        {
            public struct MinValidationContext
            {
                public int TestMinValue { get => 88; }
            }

            [Test]
            public void Equals_MinValue_IsValid()
            {

                var min = Min.Of((MinValidationContext context) => context.TestMinValue);
                var result = min.Validate(88);

                Assert.IsTrue(result);
            }

            [Test]
            public void GreaterThan_MinValue_IsValid()
            {
                var min = Min.Of((MinValidationContext context) => context.TestMinValue);
                var result = min.Validate(90);

                Assert.IsTrue(result);
            }

            [Test]
            public void LessThan_MinValue_IsNotValid()
            {
                var min = Min.Of((MinValidationContext context) => context.TestMinValue);
                var result = min.Validate(80);

                Assert.IsFalse(result);
            }
        }
    }
}