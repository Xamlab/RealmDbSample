using System;
using RealmDBSample.Core.Managers;
using RealmDBSample.UI.Services;
using RealmDBSample.UI.ViewModels.Base.Implementation;

namespace RealmDBSample.UI.ViewModels.Main.Implementation
{
    internal class BootstrapViewModel : BaseLoadableViewModel, IBootstrapViewModel
    {
        public BootstrapViewModel(INavigationService navigationService, IDataManager dataManager, IDatabaseInstallationService dbInstallationService)
        {
            LoadCommand = new BootstrapCommand(this, navigationService, dataManager, dbInstallationService);
        }

        public string Progress { get; internal set; }
    }
}
