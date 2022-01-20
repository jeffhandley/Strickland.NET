using NUnit.Framework;

namespace Strickland.Tests.ValidatorProperties
{
    public class ValidatorFunction
    {
        [TestCase(80, ExpectedResult = false)]
        [TestCase(88, ExpectedResult = true)]
        [TestCase(90, ExpectedResult = true)]
        public bool Returning_Bool_And_Properties_HasIsValid(int value)
        {
            var props = new { Message = "Speed must be at least 88mph" };
            var timeTravel = (int validatedValue) => (validatedValue >= 88, props);
            var result = Validation.Validate(value, timeTravel);

            return result.IsValid;
        }

        [TestCase(80, ExpectedResult = 80)]
        [TestCase(88, ExpectedResult = 88)]
        [TestCase(90, ExpectedResult = 90)]
        public int Returning_Bool_And_Properties_HasValue(int value)
        {
            var props = new { Message = "Speed must be at least 88mph" };
            var timeTravel = (int valiudatedValue) => (valiudatedValue >= 88, props);
            var result = Validation.Validate(value, timeTravel);

            return result.Value;
        }

        [TestCase(80)]
        [TestCase(88)]
        [TestCase(90)]
        public void Returning_Bool_And_Properties_HasProperties(int value)
        {
            var props = new { Message = "Speed must be at least 88mph" };
            var timeTravel = (int validatedValue) => (validatedValue >= 88, props);
            var result = Validation.Validate(value, timeTravel);

            Assert.AreEqual("Speed must be at least 88mph", result.Properties.Message);
        }

        struct ResultProperties
        {
            public string Message;
        }

        [TestCase(80, ExpectedResult = "You must be going at least 88mph to travel through time. Your speed is 80mph.")]
        [TestCase(88, ExpectedResult = "Your speed of 88mph was enough to travel through time!")]
        [TestCase(90, ExpectedResult = "Your speed of 90mph was enough to travel through time!")]
        public string Validator_With_IsValid_And_TypedProperties_Functions(int value)
        {
            Validator<int, ResultProperties> timeTravel = (
                (validatedValue) => validatedValue >= 88,
                (result) => new ResultProperties {
                    Message = string.Format(
                        result.IsValid ?
                        "Your speed of {0}mph was enough to travel through time!" :
                        "You must be going at least 88mph to travel through time. Your speed is {0}mph.",
                    result.Value)
                });

            var result = Validation.Validate(value, timeTravel);

            return result.Properties.Message;
        }


        [TestCase(80, ExpectedResult = "You must be going at least 88mph to travel through time. Your speed is 80mph.")]
        [TestCase(88, ExpectedResult = "Your speed of 88mph was enough to travel through time!")]
        [TestCase(90, ExpectedResult = "Your speed of 90mph was enough to travel through time!")]
        public string Validator_From_IsValid_And_AnonymousProperties_Functions(int value)
        {
            var timeTravel = Validator.From(
                (int validatedValue) => validatedValue >= 88,
                (result) => new
                {
                    Message = string.Format(
                        result.IsValid ?
                        "Your speed of {0}mph was enough to travel through time!" :
                        "You must be going at least 88mph to travel through time. Your speed is {0}mph.",
                    result.Value)
                });

            var result = Validation.Validate(value, timeTravel);

            return result.Properties.Message;
        }
    }
}
