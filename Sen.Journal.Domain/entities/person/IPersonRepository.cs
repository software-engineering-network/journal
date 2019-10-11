using System;
using System.Collections.Generic;
using System.Text;

namespace Sen.Journal.Domain
{
    public interface IPersonRepository
    {
        Person Create(Person person);
    }
}
