using Strickland.Validators;

namespace Strickland.ValidatorAttributes
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
    public abstract class ValidatorAttribute : Attribute
    {
        public static IEnumerable<Validator<T>> CreateValidators<E, T>(string memberName, Func<E, T> entityMember)
        {
            var entityType = typeof(E);
            var member = entityType.GetMember(memberName);
            var validatorAttributes = member.SelectMany(m => m.GetCustomAttributes(typeof(ValidatorAttribute), true)).OfType<ValidatorAttribute<T>>();

            return validatorAttributes.Select(attr => attr.CreateValidator());
        }
    }

    public abstract class ValidatorAttribute<T> : ValidatorAttribute
    {
        public abstract Validator<T> CreateValidator();
    }
}
