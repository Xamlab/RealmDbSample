using RealmDBSample.Core;
using RealmDBSample.UI.ViewModels.Authentication;
using RealmDBSample.UI.ViewModels.Authentication.Implementation;
using RealmDBSample.UI.ViewModels.Main;
using RealmDBSample.UI.ViewModels.Main.Implementation;
using RealmDBSample.UI.ViewModels.Store;
using RealmDBSample.UI.ViewModels.Store.Implementation;

namespace RealmDBSample.UI
{
    public static class Startup
    {
        public static IDependencyContainer RegisterUIDependencies(this IDependencyContainer container)
        {
            container.Register<IBootstrapViewModel, BootstrapViewModel>();
            container.Register<IStoreListViewModel, StoreListViewModel>();
            container.Register<IProductListViewModel, ProductListViewModel>();
            container.Register<IProductViewModel, ProductViewModel>();
            container.Register<ILogInViewModel, LogInViewModel>();
            return container;
        }
    }
}