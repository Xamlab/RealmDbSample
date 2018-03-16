using RealmDBSample.Core.Managers;
using RealmDBSample.UI.ViewModels.Base.Implementation;

namespace RealmDBSample.UI.ViewModels.Store.Implementation
{
    internal class DeleteProductCommand : Command
    {
        private readonly ProductViewModel _viewModel;
        private readonly IDataManager _dataManager;

        public DeleteProductCommand(ProductViewModel viewModel, IDataManager dataManager)
        {
            _dataManager = dataManager;
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            if(_viewModel.Product != null)
            {
                _dataManager.DeleteProduct(_viewModel.Product);
                _viewModel.DidChange?.Invoke();
            }
        }
    }
}