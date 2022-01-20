﻿using NUnit.Framework;
using Strickland.Validators;

namespace Strickland.Tests.Validators
{
    public class RangeTests
    {
        [TestCase(88, 95)]
        [TestCase(88U, 95U)]
        [TestCase(88L, 95L)]
        [TestCase(88UL, 95UL)]
        [TestCase(88F, 95F)]
        [TestCase(88D, 95D)]
        public void SetsMinLimit<T>(T minLimit, T maxLimit) where T : IComparisonOperators<T, T>
        {
            var Range = new Range<T>(minLimit, maxLimit);
            Assert.AreEqual(minLimit, Range.MinLimit);
        }

        [TestCase(88, 95)]
        [TestCase(88U, 95U)]
        [TestCase(88L, 95L)]
        [TestCase(88UL, 95UL)]
        [TestCase(88F, 95F)]
        [TestCase(88D, 95D)]
        public void SetsMaxLimit<T>(T minLimit, T maxLimit) where T : IComparisonOperators<T, T>
        {
            var Range = new Range<T>(minLimit, maxLimit);
            Assert.AreEqual(maxLimit, Range.MaxLimit);
        }

        [TestCase(88, 95, 80, ExpectedResult = false)]
        [TestCase(88, 88, 88, ExpectedResult = true)]
        [TestCase(88, 95, 95, ExpectedResult = true)]
        [TestCase(88, 95, 100, ExpectedResult = false)]
        public bool Validates<T>(T minValue, T maxValue, T value) where T : IComparisonOperators<T, T>
        {
            var Range = new Range<T>(minValue, maxValue);
            return Range.IsValid(value);
        }
    }
}
