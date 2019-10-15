namespace Sen.Journal.Domain
{
    public interface ICurrentUserProvider
    {
        Person GetCurrentUser();
    }
}
