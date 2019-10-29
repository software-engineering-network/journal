using System.ComponentModel;
using SoftwareEngineeringNetwork.JournalApplication.Domain;
using SoftwareEngineeringNetwork.JournalApplication.Services;

namespace SoftwareEngineeringNetwork.JournalApplication.Wpf
{
    public class CreateJournalDialogViewModel :
        INotifyPropertyChanged,
        ICreateJournal
    {
        #region Fields

        private readonly INotifyPropertyChanged _notifyPropertyChanged;
        private readonly IJournalManagementService _journalManagementService;

        #endregion

        #region Properties

        public ulong UserId { get; set; }
        public string JournalTitle { get; set; }

        #endregion

        #region Construction

        public CreateJournalDialogViewModel(
            INotifyPropertyChanged notifyPropertyChanged,
            IJournalManagementService journalManagementService
        )
        {
            _notifyPropertyChanged = notifyPropertyChanged;
            _journalManagementService = journalManagementService;
        }

        #endregion

        #region ICreateJournal Members

        public CreateJournal BuildCreateJournalCommand()
        {
            return new CreateJournal(
                new UserId(UserId),
                new JournalTitle(JournalTitle)
            );
        }

        public void CreateJournal()
        {
            var createJournal = BuildCreateJournalCommand();
            _journalManagementService.CreateJournal(createJournal);
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged
        {
            add => _notifyPropertyChanged.PropertyChanged += value;
            remove => _notifyPropertyChanged.PropertyChanged -= value;
        }

        #endregion
    }
}
