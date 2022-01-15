using Strickland.Validators;

namespace Strickland
{
    public static class Validation
    {
        public static bool Validate<T, ValidationContext>(Validator<T, ValidationContext> validator, T value, ValidationContext context)
        {
            return validator.Validate(value, context);
        }
    }
}
