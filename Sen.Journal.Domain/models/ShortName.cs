namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    /// <summary>
    /// An abbreviated field for a long identifier.
    /// </summary>
    public class ShortName : TinyType<string>
    {
        public ShortName(string value) : base(value)
        {
        }
    }
}