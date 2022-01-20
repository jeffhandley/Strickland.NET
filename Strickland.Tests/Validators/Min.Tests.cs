﻿using NUnit.Framework;
using Strickland.Validators;

namespace Strickland.Tests.Validators
{
    public class MinTests
    {
        [TestCase(88)]
        [TestCase(88U)]
        [TestCase(88L)]
        [TestCase(88UL)]
        [TestCase(88F)]
        [TestCase(88D)]
        public void SetsLimit<T>(T limit) where T : IComparisonOperators<T, T>
        {
            var min = new Min<T>(limit);
            Assert.AreEqual(limit, min.Limit);
        }

        [TestCase(88, 80, ExpectedResult = false)]
        [TestCase(88, 88, ExpectedResult = true)]
        [TestCase(88, 90, ExpectedResult = true)]
        public bool Validates<T>(T minValue, T value) where T : IComparisonOperators<T, T>
        {
            var min = new Min<T>(minValue);
            return min.IsValid(value);
        }
    }
}
