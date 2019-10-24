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
            var candidateRecordName = CreateCandidateRecordName(createUser);

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
            
            var quantifiers = matchingRecordNames
                .Select(
                    x => x.Value.Split(
                        new[] {candidateRecordName.Value},
                        StringSplitOptions.None
                    )[1]
                );

            var max = 0;

            foreach (var q in quantifiers)
            {
                int quantifier;

                if (!int.TryParse(q, out quantifier))
                    continue;

                if (quantifier > max)
                    max = quantifier;
            }

            return new RecordName(candidateRecordName.Value + ++max);
        }

        private static RecordName CreateCandidateRecordName(CreateUser createUser)
        {
            var recordName = (createUser.Name.Value[0] + createUser.Surname.Value).ToLower();
            return new RecordName(recordName);
        }
    }
}
