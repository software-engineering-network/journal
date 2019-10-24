using System;

namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    /// <summary>
    /// A human-readable identifier for an Entity.
    /// Usually composed from existing data on an Entity.
    /// Hides identity implementation details from clients.
    /// Eases the difficulty of communicating identity by removing the need to
    ///     copy/paste Guids or memorize integer Ids for both DBAs and end-users.
    /// 
    ///     e.g. endpoints utilizing:
    ///               Guid:  /api/users/47f7e4c0-375a-47ec-897a-531d9fd078a3
    ///                 Id:  /api/users/24
    ///         RecordName:  /api/users/jswords01
    /// </summary>
    public class RecordName : TinyType<string>
    {
        public RecordName(string value) : base(value)
        {
        }
    }

    public class SuperId
    {
        public Id Id { get; set; }
        public Guid Guid { get; set; }
        public RecordName RecordName { get; set; }
    }
}
