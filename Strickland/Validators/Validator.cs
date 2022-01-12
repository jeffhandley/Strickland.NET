namespace Strickland.Validators
{
    public abstract class Validator<T>
    {
        public abstract bool Validate(T value);
    }

    public static class ValidatorExtensions
    {
        public static bool Validate<T>(this IEnumerable<Validator<T>> validators, T value)
        {
            if (validators is null || !validators.Any())
            {
                return true;
            }

            foreach (var validator in validators)
            {
                if (!validator.Validate(value))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
