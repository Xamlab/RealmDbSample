using System;
using System.Threading;
using System.Threading.Tasks;
using RealmDBSample.Core.Managers;
using RealmDBSample.UI.Services;
using RealmDBSample.UI.ViewModels.Base.Implementation;

namespace RealmDBSample.UI.ViewModels.Authentication.Implementation
{
    internal class LogInCommand : AsyncCommand
    {
        private readonly LogInViewModel _viewModel;
        private readonly IDataManager _dataManager;
        private readonly IDialogService _dialogService;

        public LogInCommand(LogInViewModel viewModel, IDataManager dataManager, IDialogService dialogService)
        {
            _dialogService = dialogService;
            _dataManager = dataManager;
            _viewModel = viewModel;
        }

        public override async Task ExecuteAsync(object parameter, CancellationToken token = default(CancellationToken))
        {
            try
            {
                var result = await _dataManager.LogInAsync(_viewModel.Username, _viewModel.Password, _viewModel.CreateNewUser);
                if(!result) await _dialogService.ShowNotificationAsync("Login failed.");
                else _viewModel.InvokeLogInCompleted();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                await _dialogService.ShowNotificationAsync("Login failed.");
            }
        }
    }
}