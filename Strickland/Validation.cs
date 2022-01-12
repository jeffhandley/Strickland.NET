using Strickland.Validators;

namespace Strickland
{
    public static class Validation
    {
        public static bool Validate<T, C>(Validator<T> validator, T value, C context)
        {
            return validator.Validate(value, context);
        }

        public static bool Validate<T, C>(this IEnumerable<Validator<T>> validators, T value, C context)
        {
            if (validators is null || !validators.Any())
            {
                return true;
            }

            foreach (var validator in validators)
            {
                if (!validator.Validate(value, context))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
