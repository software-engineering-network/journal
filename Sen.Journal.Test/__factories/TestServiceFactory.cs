using System;

namespace SoftwareEngineeringNetwork.JournalApplication.Test
{
    public class TestServiceFactory
    {
        public static TestCurrentUserProvider CreateCurrentUserProvider()
        {
            return new TestCurrentUserProvider();
        }

        public static TestDateTimeProvider CreateDateTimeProvider(DateTime? dateTimeToProvide = null)
        {
            return new TestDateTimeProvider(dateTimeToProvide);
        }
    }
}
