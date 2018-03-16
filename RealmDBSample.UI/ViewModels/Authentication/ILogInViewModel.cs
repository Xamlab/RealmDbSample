using System;
using RealmDBSample.UI.ViewModels.Base;

namespace RealmDBSample.UI.ViewModels.Authentication
{
    public interface ILogInViewModel
    {
        IAsyncCommand LogInCommand { get; }
        string Username { get; set; }
        string Password { get; set; }
        bool CreateNewUser { get; set; }
        event EventHandler LogInCompleted;
    }
}