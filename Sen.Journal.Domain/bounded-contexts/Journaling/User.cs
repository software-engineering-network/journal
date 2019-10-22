namespace SoftwareEngineeringNetwork.JournalApplication.Domain.Journaling
{
    public class User : Entity
    {
        public Name Name { get; }

        public User(
            PersonId personId,
            Name name
        ) : base(personId)
        {
            Name = name;
        }
    }
}
