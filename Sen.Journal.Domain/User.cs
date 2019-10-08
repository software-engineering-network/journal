namespace Sen.Journal.Domain
{
    public class User
    {
        public string Email { get; }
        public string Password { get; }
        public string Username { get; }

        public User(string username, string email, string password)
        {
            Email = email;
            Password = password;
            Username = username;
        }
    }
}
