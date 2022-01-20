using NUnit.Framework;

namespace Strickland.Tests.ValidatorProperties
{
    public class ValidatorFunction
    {
        [TestCase(80, ExpectedResult = false)]
        [TestCase(88, ExpectedResult = true)]
        [TestCase(90, ExpectedResult = true)]
        public bool Validate_MinOf88_Result_IsValid(int testValue)
        {
            var props = new { Message = "Speed must be at least 88mph" };
            var min = (int value) => (value >= 88, props);
            var result = Validation.Validate(testValue, min);

            return result.IsValid;
        }

        [TestCase(80, ExpectedResult = 80)]
        [TestCase(88, ExpectedResult = 88)]
        [TestCase(90, ExpectedResult = 90)]
        public int Validate_MinOf88_Result_Value(int testValue)
        {
            var props = new { Message = "Speed must be at least 88mph" };
            var min = (int value) => (value >= 88, props);
            var result = Validation.Validate(testValue, min);

            return result.Value;
        }

        [TestCase(80)]
        [TestCase(88)]
        [TestCase(90)]
        public void Validate_MinOf88_Result_Properties(int testValue)
        {
            var props = new { Message = "Speed must be at least 88mph" };
            var min = (int value) => (value >= 88, props);
            var result = Validation.Validate(testValue, min);

            Assert.AreEqual("Speed must be at least 88mph", result.Properties.Message);
        }

        [TestCase(80, ExpectedResult = "You must be going at least 88mph to travel through time. Your speed is 80mph.")]
        [TestCase(88, ExpectedResult = "Your speed of 88mph was enough to travel through time!")]
        [TestCase(90, ExpectedResult = "Your speed of 90mph was enough to travel through time!")]
        public string Validate_MinOf88_Result_PropertiesFunction(int testValue)
        {
            var props = (ValidationResult<int> result) => new
            {
                Message = string.Format(
                    result.IsValid ?
                        "Your speed of {0}mph was enough to travel through time!" :
                        "You must be going at least 88mph to travel through time. Your speed is {0}mph.",
                    result.Value)
            };

            var min = (int value) => (value >= 88, props);
            var result = Validation.Validate(testValue, min);

            return result.Properties(result).Message;
        }
    }
}
