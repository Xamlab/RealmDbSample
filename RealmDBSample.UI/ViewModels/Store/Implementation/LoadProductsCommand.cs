using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using RealmDBSample.Core.Managers;
using RealmDBSample.Core.Models;
using RealmDBSample.UI.ViewModels.Base.Implementation;

namespace RealmDBSample.UI.ViewModels.Store.Implementation
{
    internal class LoadProductsCommand : LoadAsyncCommand
    {
        private readonly ProductListViewModel _viewModel;
        private readonly IDataManager _dataManager;

        public LoadProductsCommand(ProductListViewModel viewModel, IDataManager dataManager) : base(viewModel)
        {
            _dataManager = dataManager;
            _viewModel = viewModel;
        }

        protected override Task ExecuteCoreAsync(object param, CancellationToken token = default(CancellationToken))
        {
            _viewModel.Items = _dataManager.FetchAllProducts(_viewModel.Store);
            //_viewModel.Items = Enumerable.Range(1, 10000).Select(index => new Product()
            //                                                              {
            //                                                                  Name = $"Product {index}",
            //                                                                  Price = index,
            //                                                                  Category = new Category()
            //                                                                             {
            //                                                                                 Name = $"Category {index}"
            //                                                                             }
            //                                                              }).ToList();
            return Task.CompletedTask;
        }
    }
}