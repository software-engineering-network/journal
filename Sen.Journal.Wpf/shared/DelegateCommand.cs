using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace SoftwareEngineeringNetwork.JournalApplication.Wpf
{
    public class DelegateCommand1 : ICommand
    {
        #region Fields

        private readonly Func<bool> _canExecuteCommand;

        private readonly Action _executeCommand;

        #endregion

        #region Construction

        public DelegateCommand1(
            Action executeCommand,
            Func<bool> canExecuteCommand
        )
        {
            _executeCommand = executeCommand;
            _canExecuteCommand = canExecuteCommand;
        }

        #endregion

        #region ICommand Members

        public bool CanExecute(object parameter)
        {
            return _canExecuteCommand.Invoke();
        }

        public void Execute(object parameter)
        {
            _executeCommand.Invoke();
        }

        public event EventHandler CanExecuteChanged;

        #endregion
    }

    public class DelegateCommand : ICommand
    {
        #region Fields

        private readonly Func<bool> canExecuteMethod;
        private readonly Dispatcher dispatcher;

        private readonly Action executeMethod;
        private EventHandler canExecuteChanged;

        #endregion

        #region Construction

        public DelegateCommand(Action executeMethod)
            : this(executeMethod, null)
        {
        }

        public DelegateCommand(Action executeMethod, Func<bool> canExecuteMethod)
        {
            if (executeMethod == null && canExecuteMethod == null)
                throw new ArgumentNullException(nameof(executeMethod), "Delegate commands cannot be null");
            this.executeMethod = executeMethod;
            this.canExecuteMethod = canExecuteMethod;
            if (Application.Current == null)
                return;
            dispatcher = Application.Current.Dispatcher;
        }

        #endregion

        #region ICommand Members

        bool ICommand.CanExecute(object parameter)
        {
            return CanExecute();
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (canExecuteMethod == null)
                    return;
                canExecuteChanged += value;
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                if (canExecuteMethod == null)
                    return;
                canExecuteChanged -= value;
                CommandManager.RequerySuggested -= value;
            }
        }

        void ICommand.Execute(object parameter)
        {
            Execute();
        }

        #endregion

        public bool CanExecute()
        {
            if (canExecuteMethod == null)
                return true;
            return canExecuteMethod();
        }

        public void Execute()
        {
            if (executeMethod == null)
                return;
            executeMethod();
        }

        public void RaiseCanExecuteChanged()
        {
            OnCanExecuteChanged();
        }

        protected virtual void OnCanExecuteChanged()
        {
            var canExecuteChanged = this.canExecuteChanged;
            if (canExecuteChanged == null)
                return;
            if (dispatcher != null && !dispatcher.CheckAccess())
                dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(OnCanExecuteChanged));
            else
                canExecuteChanged(this, EventArgs.Empty);
        }
    }
}
