using Strickland.Validators;

namespace Strickland.ValidatorAttributes
{
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
    public abstract class ValidatorAttribute : Attribute
    {
        public static IEnumerable<Validator<T, object?>> CreateValidators<E, T>(string memberName, Func<E, T> entityMember)
        {
            var entityType = typeof(E);
            var member = entityType.GetMember(memberName);
            var validatorAttributes = member.SelectMany(m => m.GetCustomAttributes(typeof(ValidatorAttribute), true)).OfType<ValidatorAttribute<T>>();

            return validatorAttributes.Select(attr => attr.CreateValidator());
        }

        public static IEnumerable<Validator<T, ValidationContext>> CreateValidators<E, T, ValidationContext>(string memberName, Func<E, T> entityMember)
        {
            var entityType = typeof(E);
            var member = entityType.GetMember(memberName);
            var validatorAttributes = member.SelectMany(m => m.GetCustomAttributes(typeof(ValidatorAttribute), true)).OfType<ValidatorAttribute<T>>();

            return validatorAttributes.Select(attr => attr.CreateValidator<ValidationContext>());
        }
    }

    public abstract class ValidatorAttribute<T> : ValidatorAttribute
    {
        public abstract Validator<T, ValidationContext> CreateValidator<ValidationContext>();
        public abstract Validator<T, object?> CreateValidator();
    }
}
