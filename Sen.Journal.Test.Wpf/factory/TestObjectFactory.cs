using SoftwareEngineeringNetwork.JournalApplication.Domain;

namespace SoftwareEngineeringNetwork.JournalApplication.Test.Wpf
{
    public class TestObjectFactory
    {
        public static ICurrentUserProvider CreateCurrentUserProvider()
        {
            return new JohnDoeCurrentUserProvider();
        }
    }
}