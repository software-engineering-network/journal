namespace Sen.Journal.Domain
{
    public class EmailAddress : TinyType<string>
    {
        public EmailAddress(string value) : base(value)
        {
        }
    }
}