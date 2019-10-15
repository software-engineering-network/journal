using System;

namespace Sen.Journal.Domain
{
    public interface IDateTimeProvider
    {
        DateTime Now();
    }
}
