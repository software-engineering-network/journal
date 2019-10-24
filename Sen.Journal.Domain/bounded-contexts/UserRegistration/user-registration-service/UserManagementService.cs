namespace SoftwareEngineeringNetwork.JournalApplication.Domain.UserRegistration
{
    public class UserManagementService : IUserManagementService
    {
        private readonly IRepository<Person> _userRepository;

        public UserManagementService(IRepository<Person> userRepository)
        {
            _userRepository = userRepository;
        }

        public void CreateUser(CreateUserArgs args)
        {
            var recordName = GetRecordName(args);

            var user = new User(
                new EmailAddress(args.EmailAddress),
                new Name(args.Name),
                new Password(args.Password),
                new RecordName(""), 
                new Surname(args.Surname),
                new Username(args.Username)
            );

            _userRepository.Create(user);
        }

        private RecordName GetRecordName(CreateUserArgs args)
        {
            var candidateRecordName = new RecordName(args.Name + args.Surname);

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

            var matchingRecordNames = _userRepository.WithMatchingRecordNames(candidateRecordName);
            
        }
    }
}