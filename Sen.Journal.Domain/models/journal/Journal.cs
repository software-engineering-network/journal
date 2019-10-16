﻿namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public class Journal : Entity
    {
        public PersonId PersonId { get; private set; }
        public JournalTitle JournalTitle { get; private set; }

        public Journal(
            PersonId personId,
            JournalTitle journalTitle,
            JournalId journalId = null
        ) : base(journalId)
        {
            PersonId = personId;
            JournalTitle = journalTitle;
        }

        public Journal Update(
            PersonId personId,
            JournalTitle journalTitle
        )
        {
            PersonId = personId;
            JournalTitle = journalTitle;
            return this;
        }
    }
}
