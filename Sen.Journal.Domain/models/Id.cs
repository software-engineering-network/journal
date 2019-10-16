namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public class Id : TinyType<ulong>
    {
        public Id(ulong value) : base(value)
        {
        }
    }
}
