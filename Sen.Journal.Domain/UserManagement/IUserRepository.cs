using System.Collections.Generic;

namespace SoftwareEngineeringNetwork.JournalApplication.Domain.UserManagement
{
    public interface IUserRepository : IRepository<User>
    {
        User Find(Username username);
        IEnumerable<RecordName> FindMatchingRecordNames(RecordName recordName);
        bool RecordNameExists(RecordName recordName);
        bool UsernameExists(Username username);
    }
}
