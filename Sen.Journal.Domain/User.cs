namespace Sen.Journal.Domain
{
    public class User
    {
        public string Email { get; }
        public string Password { get; }
        public Username Username { get; }

        public User(string email, string password, Username username)
        {
            Email = email;
            Password = password;
            Username = username;
        }
    }
}
