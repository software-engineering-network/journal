namespace SoftwareEngineeringNetwork.JournalApplication.Domain.Journaling
{
    public class User : Entity
    {
        public Name Name { get; }

        public User(
            UserId userId,
            Name name
        ) : base(userId)
        {
            Name = name;
        }
    }
}
