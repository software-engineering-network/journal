using System;
using System.Linq;

namespace SoftwareEngineeringNetwork.JournalApplication.Domain.UserManagement
{
    public class UserManager : IUserManager
    {
        #region Fields

        private readonly CreateUserCommandValidator _createUserCommandValidator;
        private readonly IUserRepository _userRepository;

        #endregion

        #region Construction

        public UserManager(
            IUserRepository userRepository,
            CreateUserCommandValidator createUserCommandValidator
        )
        {
            _userRepository = userRepository;
            _createUserCommandValidator = createUserCommandValidator;
        }

        #endregion

        #region IUserManager Members

        public void CreateUser(CreateUserCommand createUserCommand)
        {
            var validationResult = _createUserCommandValidator.Validate(createUserCommand);

            if (!validationResult.IsValid)
                return;

            var user = new User(
                createUserCommand.EmailAddress,
                createUserCommand.Name,
                createUserCommand.Password,
                CreateRecordName(createUserCommand),
                createUserCommand.Surname,
                createUserCommand.Username
            );

            _userRepository.Create(user);
        }

        #endregion

        private RecordName CreateRecordName(CreateUserCommand command)
        {
            var candidateRecordName = new RecordName(command.Name.Value + command.Surname.Value);

            /*
             * if the candidate doesn't exist
             *     return the candidate
             * else if the candidate does exist
             *     find all RecordNames that match the candidate
             *     parse to the candidate and the modifier (integer)
             *     increment the modifier and append to the candidate
             *     return the above
             */

            // check recordname exists
            if (_userRepository.FirstOrDefault(x => x.RecordName == candidateRecordName) == null)
                return candidateRecordName;

            var matchingRecordNames = _userRepository.FindMatchingRecordNames(candidateRecordName);

            var maxQuantifier = matchingRecordNames
                .Select(
                    x => x.Value.Split(
                        new [] {x.Value},
                        StringSplitOptions.None
                    )[1]
                )
                .Max(int.Parse);

            return new RecordName(candidateRecordName.Value + ++maxQuantifier);
        }
    }
}
