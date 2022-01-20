namespace Strickland.Composition
{
    public class All<T> : IValidator<T>
    {
        private IEnumerable<IValidator<T>> _validators;

        public All(params IValidator<T>[] validators)
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
