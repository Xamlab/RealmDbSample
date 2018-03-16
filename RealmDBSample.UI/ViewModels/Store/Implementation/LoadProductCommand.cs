using System.Threading;
using System.Threading.Tasks;
using RealmDBSample.Core.Managers;
using RealmDBSample.UI.ViewModels.Base.Implementation;

namespace RealmDBSample.UI.ViewModels.Store.Implementation
{
    internal class LoadProductCommand : LoadAsyncCommand
    {
        private readonly ProductViewModel _viewModel;
        private readonly IDataManager _dataManager;

        public LoadProductCommand(ProductViewModel viewModel, IDataManager dataManager) : base(viewModel)
        {
            _dataManager = dataManager;
            _viewModel = viewModel;
        }

        protected override async Task ExecuteCoreAsync(object param, CancellationToken token = default(CancellationToken))
        {
            if(string.IsNullOrEmpty(_viewModel.ProductId))
            {
                _viewModel.Product = null;
                return;
            }

            _viewModel.Product = _dataManager.FetchProductById(_viewModel.ProductId);
            if(_viewModel.Product == null) return;
            _viewModel.Name = _viewModel.Product.Name;
            _viewModel.Price = _viewModel.Product.Price;
            _viewModel.Categories = _dataManager.FetchAllCategories();
            //var index = 0;

            //foreach(var category in _viewModel.Categories)
            //{
            //    if(category.Id == _viewModel.Product.Category.Id) break;
            //    index++;
            //}

            _viewModel.SelectedCategory = _viewModel.Product.Category;
        }
    }
}