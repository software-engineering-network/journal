using System.ComponentModel;

namespace SoftwareEngineeringNetwork.JournalApplication.Wpf
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        #region Fields

        private readonly INotifyPropertyChanged _notifyPropertyChanged;

        #endregion

        #region Construction

        protected ViewModelBase(INotifyPropertyChanged notifyPropertyChanged)
        {
            _notifyPropertyChanged = notifyPropertyChanged;
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
