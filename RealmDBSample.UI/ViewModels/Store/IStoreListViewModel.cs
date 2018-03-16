using RealmDBSample.UI.ViewModels.Base;

namespace RealmDBSample.UI.ViewModels.Store
{
    public interface IStoreListViewModel : ICollectionViewModel<Core.Models.Store>
    {
        IAsyncCommand LogOutCommand { get; }
    }
}