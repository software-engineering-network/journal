﻿using System.Collections.Generic;

namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public interface IUserRepository : IRepository<User>
    {
        User Find(Username username);
        IEnumerable<RecordName> FindMatchingRecordNames(RecordName recordName);
        bool RecordNameExists(RecordName recordName);
        bool UserIdExists(UserId userId);
        bool UsernameExists(Username username);
    }
}
