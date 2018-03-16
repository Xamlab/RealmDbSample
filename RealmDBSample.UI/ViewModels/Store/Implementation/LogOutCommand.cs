using System;
using System.Threading;
using System.Threading.Tasks;
using RealmDBSample.Core.Managers;
using RealmDBSample.UI.Services;
using RealmDBSample.UI.ViewModels.Base.Implementation;

namespace RealmDBSample.UI.ViewModels.Store.Implementation
{
    internal class LogOutCommand : AsyncCommand
    {
        private readonly IAuthenticationManager _authenticationManager;
        private readonly IDialogService _dialogService;

        public LogOutCommand(IAuthenticationManager authManager, IDialogService dialogService)
        {
            _dialogService = dialogService;
            _authenticationManager = authManager;
        }

        public override async Task ExecuteAsync(object parameter, CancellationToken token = default(CancellationToken))
        {
            try
            {
                _authenticationManager.SignOut();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                await _dialogService.ShowNotificationAsync("Logging out failed.");
            }
        }
    }
}