using System;

namespace SoftwareEngineeringNetwork.JournalApplication.Domain
{
    public class Auditable : IAuditable
    {
        #region Fields

        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly IDateTimeProvider _dateTimeProvider;

        #endregion

        #region Properties

        private UserId CurrentUserId => (UserId) _currentUserProvider.GetCurrentUser().Id;
        private bool IsCreated => CreatedBy != null && CreatedDate != null;
        private DateTime Now => _dateTimeProvider.Now;

        #endregion

        #region Construction

        public Auditable(
            ICurrentUserProvider currentUserProvider,
            IDateTimeProvider dateTimeProvider
        )
        {
            _currentUserProvider = currentUserProvider;
            _dateTimeProvider = dateTimeProvider;
        }

        #endregion

        #region IAuditable Members

        public UserId CreatedBy { get; private set; }
        public DateTime? CreatedDate { get; private set; }
        public UserId ModifiedBy { get; private set; }
        public DateTime? ModifiedDate { get; private set; }

        public IAuditable Update()
        {
            if (!IsCreated)
                SetCreated();

            SetModified();

            return this;
        }

        #endregion

        private void SetCreated()
        {
            CreatedBy = CurrentUserId;
            CreatedDate = Now;
        }

        private void SetModified()
        {
            ModifiedBy = CurrentUserId;
            ModifiedDate = Now;
        }
    }
}
