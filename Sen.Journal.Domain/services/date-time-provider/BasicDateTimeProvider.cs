using System;

namespace Sen.Journal.Domain
{
    public class BasicDateTimeProvider : IDateTimeProvider
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }
    }
}
