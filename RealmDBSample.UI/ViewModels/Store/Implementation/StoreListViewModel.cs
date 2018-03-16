using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using RealmDBSample.Core.Managers;
using RealmDBSample.UI.Services;
using RealmDBSample.UI.ViewModels.Base;
using RealmDBSample.UI.ViewModels.Base.Implementation;

namespace RealmDBSample.UI.ViewModels.Store.Implementation
{
    internal class StoreListViewModel : BaseCollectionViewModel<Core.Models.Store>, IStoreListViewModel
    {
        public StoreListViewModel(IDataManager dataManager, IAuthenticationManager authManager, IDialogService dialogService)
        {
            LoadCommand = new LoadStoresCommand(this, dataManager);
            LogOutCommand = new LogOutCommand(authManager, dialogService);
        }

        public IAsyncCommand LogOutCommand { get; }
    }

    internal class LoadStoresCommand : LoadAsyncCommand
    {
        private readonly IDataManager _dataManager;
        private readonly StoreListViewModel _viewModel;

        public LoadStoresCommand(StoreListViewModel viewModel, IDataManager dataManager) : base(viewModel)
        {
            _viewModel = viewModel;
            _dataManager = dataManager;
        }

        protected override Task ExecuteCoreAsync(object param, CancellationToken token = default(CancellationToken))
        {
            _viewModel.Items = _dataManager.FetchAllStores();
            return Task.CompletedTask;
        }
    }
}
