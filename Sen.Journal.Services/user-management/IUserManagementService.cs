using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using SoftwareEngineeringNetwork.JournalApplication.Domain;

namespace SoftwareEngineeringNetwork.JournalApplication.Services
{
    public interface IUserManagementService
    {
        IUserManagementService CreateUser(CreateUser createUser);
        ValidationResult ValidateCreateUser(CreateUser createUser);
    }

    public class ValidationResult
    {
        public bool IsValid { get; }
        public ICollection<string> ErrorMessages { get; private set; }

        public ValidationResult(FluentValidation.Results.ValidationResult validationResult)
        {
            IsValid = validationResult.IsValid;

            ErrorMessages = new List<string>();
            SetErrorMessages(validationResult.Errors);
        }

        private void SetErrorMessages(IEnumerable<ValidationFailure> validationFailures)
        {
            foreach (var validationFailure in validationFailures)
                ErrorMessages.Add(validationFailure.ErrorMessage);
        }
    }
}
