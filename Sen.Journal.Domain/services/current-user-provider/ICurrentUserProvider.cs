namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public interface ICurrentUserProvider
    {
        Person GetCurrentUser();
    }
}
