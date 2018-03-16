using System.Threading;
using System.Threading.Tasks;
using RealmDBSample.Core.Managers;
using RealmDBSample.UI.Services;
using RealmDBSample.UI.ViewModels.Base.Implementation;

namespace RealmDBSample.UI.ViewModels.Store.Implementation
{
    internal class SaveProductCommand : SaveAsyncCommand
    {
        private readonly ProductViewModel _viewModel;
        private readonly IDataManager _dataManager;

        public SaveProductCommand(ProductViewModel viewModel, IDataManager dataManager, IDialogService dialogService) :base(viewModel, dialogService)
        {
            _dataManager = dataManager;
            _viewModel = viewModel;
        }

        protected override Task ExecuteCoreAsync(object param, CancellationToken token = default(CancellationToken))
        {
            _dataManager.SaveProduct(_viewModel.Product, _viewModel.Name, _viewModel.Price, _viewModel.SelectedCategory);
            _viewModel.DidChange?.Invoke();
            return Task.CompletedTask;
        }
    }
}