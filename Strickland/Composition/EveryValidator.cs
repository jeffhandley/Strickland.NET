namespace Strickland.Composition
{
    public class EveryValidator<T> : IValidatorFunction<T>
    {
        private IEnumerable<IValidatorFunction<T>> _validators;

        public EveryValidator(params IValidatorFunction<T>[] validators)
        {
            _validators = validators;
        }

        public bool IsValid(T value)
        {
            foreach (var validator in _validators)
            {
                if (!validator.IsValid(value))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
