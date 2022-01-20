namespace Strickland.Composition
{
    public class SomeValidator<T> : IValidatorFunction<T>
    {
        private IEnumerable<IValidatorFunction<T>> _validators;

        public SomeValidator(params IValidatorFunction<T>[] validators)
        {
            _validators = validators;
        }

        public bool IsValid(T value)
        {
            foreach (var validator in _validators)
            {
                if (validator.IsValid(value))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
