using System;
using System.Collections.Generic;
using System.Text;
using PropertyChanged;
using RealmDBSample.Core.Managers;
using RealmDBSample.UI.Services;
using RealmDBSample.UI.ViewModels.Base;

namespace RealmDBSample.UI.ViewModels.Authentication.Implementation
{
    [AddINotifyPropertyChangedInterface]
    internal class LogInViewModel : ILogInViewModel
    {
        public LogInViewModel(IDataManager dataManager, IDialogService dialogService)
        {
            LogInCommand = new LogInCommand(this, dataManager, dialogService);
        }
        public IAsyncCommand LogInCommand { get; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool CreateNewUser { get; set; }
        public event EventHandler LogInCompleted;

        internal void InvokeLogInCompleted()
        {
            LogInCompleted?.Invoke(this, EventArgs.Empty);
        }
    }
}
