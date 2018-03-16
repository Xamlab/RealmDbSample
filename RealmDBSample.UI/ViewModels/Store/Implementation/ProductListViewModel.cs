using PropertyChanged;
using RealmDBSample.Core.Managers;
using RealmDBSample.Core.Models;
using RealmDBSample.UI.ViewModels.Base.Implementation;

namespace RealmDBSample.UI.ViewModels.Store.Implementation
{
    [AddINotifyPropertyChangedInterface]
    internal class ProductListViewModel : BaseCollectionViewModel<Product>, IProductListViewModel
    {
        public ProductListViewModel(IDataManager dataManager)
        {
            LoadCommand = new LoadProductsCommand(this, dataManager);
        }

        public Core.Models.Store Store { get; set; }
    }
}