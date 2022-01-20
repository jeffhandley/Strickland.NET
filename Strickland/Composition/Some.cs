namespace Strickland.Composition
{
    public class Some<T> : IValidator<T>
    {
        private IEnumerable<IValidator<T>> _validators;

        public Some(params IValidator<T>[] validators)
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
