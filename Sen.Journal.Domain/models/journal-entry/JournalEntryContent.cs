namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public class JournalEntryContent : TinyType<string>
    {
        public JournalEntryContent(string value) : base(value)
        {
        }
    }
}