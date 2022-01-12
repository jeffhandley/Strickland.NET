using NUnit.Framework;
using System.Collections.Generic;

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

        [Test]
        public void Accepts_Properties()
        {
            var min = new Min<int>(88, new Dictionary<string, object?>() { { "Year", 1985 } });
            Assert.AreEqual(1985, min.Properties["Year"]);
        }

        [Test]
        public void Exposes_MinValue_InProperties()
        {
            var min = new Min<int>(88);
            Assert.AreEqual(88, min.Properties[nameof(Min<int>.MinValue)]);
        }
    }
}