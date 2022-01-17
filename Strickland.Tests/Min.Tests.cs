using NUnit.Framework;

namespace Strickland.Validators.Tests
{
    public class MinTests
    {
        [TestCase(88, 88, true), TestCase(88, 90, true), TestCase(88, 80, false)]
        [TestCase(88.0, 88.0, true), TestCase(88.0, 90.0, true), TestCase(88.0, 80.0, false)]
        public void Valdates_AsFunction<T>(T minValue, T value, bool expected) where T : IComparisonOperators<T, T>
        {
            var min = Min.Of(minValue);
            var isValid = min.IsValid(value);

            Assert.AreEqual(expected, isValid);
        }

        private struct TestContext<T>
        {
            public T MinValue;
        }

        private class MinFactory<T> : IValidatorFactory<TestContext<T>, Min<T>, T>
            where T : IComparisonOperators<T, T>
        {
            public Min<T> GetValidator(TestContext<T> context) => Min.Of(context.MinValue);
        }

        public void Validates_ThroughFactoryFunction()
        {
            var context = new TestContext<int> { MinValue = 88 };
            var isValid = Validation.IsValid(context, (TestContext<int> c) => Min.Of(c.MinValue), 90);

            Assert.IsTrue(isValid);
        }

        public void Validates_ThroughFactoryInstance()
        {
            var factory = new MinFactory<float>();
            var context = new TestContext<float> { MinValue = 88f };
            var isValid = Validation.IsValid(context, factory, 90f);

            Assert.IsTrue(isValid);
        }
    }
}