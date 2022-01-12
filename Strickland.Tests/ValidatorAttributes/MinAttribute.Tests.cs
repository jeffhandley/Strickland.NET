using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Strickland.ValidatorAttributes.MinAttribute.Tests
{
    public class MinAttributeTests
    {
        private class TimeTravel
        {
            [Min<int>(88)]
            public int Speed { get; set; }

            [Min<int>(1985)]
            public int GetDestinationYear()
            {
                return 1885;
            }
        }

        public class CanCreateValidator
        {
            [Test]
            public void FromType_Dynamically()
            {
                var entityType = typeof(TimeTravel);
                var speedProp = entityType.GetProperty("Speed")!;
                var validatorAttributeType = typeof(ValidatorAttribute);
                var validatorAttrs = speedProp.GetCustomAttributes(validatorAttributeType, true);
                dynamic minAttr = validatorAttrs.First();
                var validator = minAttr.CreateValidator();

                Assert.IsNotNull(validator);
            }

            [Test]
            public void FromType_Statically()
            {
                var entityType = typeof(TimeTravel);
                var speedProp = entityType.GetProperty("Speed")!;
                var validatorAttributeType = typeof(ValidatorAttribute);
                var validatorAttrs = speedProp.GetCustomAttributes(validatorAttributeType, true);
                var minAttr = (ValidatorAttribute<int>)validatorAttrs.First();
                var validator = minAttr.CreateValidator();

                Assert.IsNotNull(validator);
            }

            [Test]
            public void FromInstance_AndPropertyReference()
            {
                var entity = new TimeTravel { Speed = 88 };
                var validators = ValidatorAttribute.CreateValidators(nameof(entity.Speed), (TimeTravel e) => e.Speed);

                Assert.IsNotEmpty(validators);
            }

            [Test]
            public void FromInstance_AndMethodReference()
            {
                var entity = new TimeTravel();
                var validators = ValidatorAttribute.CreateValidators(nameof(entity.GetDestinationYear), (TimeTravel e) => e.GetDestinationYear());

                Assert.IsNotEmpty(validators);
            }

            [Test]
            public void WithProperties()
            {
                var entity = new TimeTravel();
                var validator = ValidatorAttribute.CreateValidators(nameof(entity.Speed), (TimeTravel e) => e.Speed).Single();

                Assert.AreEqual(88, validator.Properties[nameof(MinAttribute<int>.MinValue)]);
            }
        }

        public class Validates
        {
            [Test]
            public void Equals_MinValue_IsValid()
            {
                var entity = new TimeTravel { Speed = 88 };
                var validator = ValidatorAttribute.CreateValidators(nameof(entity.Speed), (TimeTravel e) => e.Speed).Single();
                var result = validator.Validate(entity.Speed);

                Assert.IsTrue(result);
            }

            [Test]
            public void GreaterThan_MinValue_IsValid()
            {
                var entity = new TimeTravel { Speed = 90 };
                var validator = ValidatorAttribute.CreateValidators(nameof(entity.Speed), (TimeTravel e) => e.Speed).Single();
                var result = validator.Validate(entity.Speed);

                Assert.IsTrue(result);
            }

            [Test]
            public void LessThan_MinValue_IsNotValid()
            {
                var entity = new TimeTravel { Speed = 80 };
                var validator = ValidatorAttribute.CreateValidators(nameof(entity.Speed), (TimeTravel e) => e.Speed).Single();
                var result = validator.Validate(entity.Speed);

                Assert.IsFalse(result);
            }
        }
    }
}
