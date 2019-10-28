using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation;
using SoftwareEngineeringNetwork.JournalApplication.Domain;

namespace SoftwareEngineeringNetwork.JournalApplication.Services
{
    public class JournalManagementService : IJournalManagementService
    {
        #region Fields

        private readonly CreateJournalValidator _createJournalValidator;
        private readonly IJournalRepository _journalRepository;

        #endregion

        #region Construction

        public JournalManagementService(
            CreateJournalValidator createJournalValidator,
            IJournalRepository journalRepository
        )
        {
            _createJournalValidator = createJournalValidator;
            _journalRepository = journalRepository;
        }

        #endregion

        #region IJournalManagementService Members

        public IJournalManagementService CreateJournal(CreateJournal createJournal)
        {
            _createJournalValidator.ValidateAndThrowCustom(createJournal);

            var journal = new Journal(
                createJournal.UserId,
                createJournal.JournalTitle
            );

            _journalRepository.Create(journal);

            return this;
        }

        #endregion
    }

    public static class AbstractValidatorExtensions
    {
        public static void ValidateAndThrowCustom<T>(this AbstractValidator<T> validator, T command)
        {
            var validationResult = validator.Validate(command);

            if (validationResult.IsValid)
                return;

            var errorMessages = validationResult.Errors.Select(x => x.ErrorMessage);

            throw new InvalidCommandException(errorMessages);
        }
    }

    public class InvalidCommandException : Exception
    {
        private readonly IEnumerable<string> _errorMessages;

        public InvalidCommandException(IEnumerable<string> errorMessages)
            : base(errorMessages.First())
        {
            _errorMessages = errorMessages;
        }
    }
}
