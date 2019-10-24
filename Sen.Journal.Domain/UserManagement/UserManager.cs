using System;
using System.Linq;

namespace SoftwareEngineeringNetwork.JournalApplication.Domain.UserManagement
{
    public class UserManager : IUserManager
    {
        #region Fields

        private readonly IUserRepository _userRepository;

        #endregion

        #region Construction

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        #endregion

        #region IUserManager Members

        public void CreateUser(CreateUser createUser)
        {
            var user = new User(
                createUser.EmailAddress,
                createUser.Name,
                createUser.Password,
                CreateRecordName(createUser),
                createUser.Surname,
                createUser.Username
            );

            _userRepository.Create(user);
        }

        #endregion

        private RecordName CreateRecordName(CreateUser createUser)
        {
            var candidateRecordName = new RecordName(createUser.Name.Value + createUser.Surname.Value);

            /*
             * if the candidate doesn't exist
             *     return the candidate
             * else if the candidate does exist
             *     find all RecordNames that match the candidate
             *     parse to the candidate and the modifier (integer)
             *     increment the modifier and append to the candidate
             *     return the above
             */
            if (!_userRepository.RecordNameExists(candidateRecordName))
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
