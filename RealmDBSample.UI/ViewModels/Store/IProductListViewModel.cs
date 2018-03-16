using RealmDBSample.Core.Models;
using RealmDBSample.UI.ViewModels.Base;

namespace RealmDBSample.UI.ViewModels.Store
{
    public interface IProductListViewModel : ICollectionViewModel<Product>
    {
        Core.Models.Store Store { get; set; }
    }
}