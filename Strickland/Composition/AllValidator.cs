namespace Strickland.Composition
{
    public class AllValidator<T> : IValidatorFunction<T>
    {
        private IEnumerable<IValidatorFunction<T>> _validators;

        public AllValidator(params IValidatorFunction<T>[] validators)
        {
            _validators = validators;
        }

        public bool IsValid(T value)
        {
            var isValid = true;

            foreach (var validator in _validators)
            {
                if (!validator.IsValid(value))
                {
                    isValid = false;
                }
            }

            return isValid;
        }
    }
}
