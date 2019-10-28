using System.Linq;
using System.Text;
using FluentValidation;

namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public static class AbstractValidatorExtensions
    {
        public static void ValidateAndThrowCustom<T>(this AbstractValidator<T> validator, T command)
        {
            var validationResult = validator.Validate(command);

            if (validationResult.IsValid)
                return;

            var stringBuilder = new StringBuilder();

            foreach (var errorMessage in validationResult.Errors.Select(x => x.ErrorMessage))
                stringBuilder.AppendLine(errorMessage);

            throw new InvalidCommandException(stringBuilder.ToString());
        }
    }
}
