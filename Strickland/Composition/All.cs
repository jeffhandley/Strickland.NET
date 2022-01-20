namespace Strickland.Composition
{
    public class Every<T> : IValidator<T>
    {
        private IEnumerable<IValidator<T>> _validators;

        public Every(params IValidator<T>[] validators)
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
