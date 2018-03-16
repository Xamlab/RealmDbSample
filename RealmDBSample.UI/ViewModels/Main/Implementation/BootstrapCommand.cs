using System;
using System.Threading;
using System.Threading.Tasks;
using RealmDBSample.Core.Managers;
using RealmDBSample.UI.Services;
using RealmDBSample.UI.ViewModels.Base.Implementation;

namespace RealmDBSample.UI.ViewModels.Main.Implementation
{
    internal class BootstrapCommand : LoadAsyncCommand, IProgress<string>
    {
        private readonly IDataManager _dataManager;
        private readonly BootstrapViewModel _viewModel;
        private readonly IDatabaseInstallationService _databaseInstallationService;
        private readonly INavigationService _navigationService;

        public BootstrapCommand(BootstrapViewModel viewModel, INavigationService navigationService, IDataManager dataManager, IDatabaseInstallationService dbInstallationService) : base(viewModel)
        {
            _navigationService = navigationService;
            _databaseInstallationService = dbInstallationService;
            _viewModel = viewModel;
            _dataManager = dataManager;
        }

        protected override async Task ExecuteCoreAsync(object param, CancellationToken token = default(CancellationToken))
        {
            //await _databaseInstallationService.InstallDatabase(_dataManager.DatabasePath);
            await _dataManager.Bootstrap(this);
            _navigationService.ShowMainPage();
        }

        public void Report(string value)
        {
            _viewModel.Progress = value;
        }
    }
}