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

            Assert.IsTrue(result.IsValid);
        }

        [Test]
        public void GreaterThan_MinValue_IsValid()
        {
            var min = Min.Of(88);
            var result = min.Validate(90);

            Assert.IsTrue(result.IsValid);
        }

        [Test]
        public void LessThan_MinValue_IsNotValid()
        {
            var min = Min.Of(88);
            var result = min.Validate(80);

            Assert.IsFalse(result.IsValid);
        }

        public class UsingFuncWithoutValidationContext
        {
            [Test]
            public void Equals_MinValue_IsValid()
            {
                var min = Min.Of(() => 88);
                var result = min.Validate(88);

                Assert.IsTrue(result.IsValid);
            }

            [Test]
            public void GreaterThan_MinValue_IsValid()
            {
                var min = Min.Of(() => 88);
                var result = min.Validate(90);

                Assert.IsTrue(result.IsValid);
            }

            [Test]
            public void LessThan_MinValue_IsNotValid()
            {
                var min = Min.Of(() => 88);
                var result = min.Validate(80);

                Assert.IsFalse(result.IsValid);
            }
        }

        public class UsingFuncWithValidationContext
        {
            public class MinValidationContext
            {
                public int TestMinValue { get => 88; }
            }

            [Test]
            public void Equals_MinValue_IsValid()
            {

                var min = Min.Of((MinValidationContext? context) => context!.TestMinValue);
                var result = min.Validate(88, new MinValidationContext());

                Assert.IsTrue(result.IsValid);
            }

            [Test]
            public void GreaterThan_MinValue_IsValid()
            {
                var min = Min.Of((MinValidationContext? context) => context!.TestMinValue);
                var result = min.Validate(90, new MinValidationContext());

                Assert.IsTrue(result.IsValid);
            }

            [Test]
            public void LessThan_MinValue_IsNotValid()
            {
                var min = Min.Of((MinValidationContext? context) => context!.TestMinValue);
                var result = min.Validate(80, new MinValidationContext());

                Assert.IsFalse(result.IsValid);
            }

            [Test]
            public void ResultContainsContext()
            {
                var min = Min.Of((MinValidationContext? context) => context!.TestMinValue);
                var result = min.Validate(90, new MinValidationContext());

                Assert.IsNotNull(result.Context);
                Assert.AreEqual(88, result.Context!.TestMinValue);
            }
        }
    }
}