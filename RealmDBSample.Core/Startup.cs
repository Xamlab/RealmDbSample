using RealmDBSample.Core.Managers;
using RealmDBSample.Core.Managers.Implementation;

namespace RealmDBSample.Core
{
    public static class Startup
    {
        public static IDependencyContainer RegisterCoreDependencies(this IDependencyContainer container)
        {
            container.RegisterSingleton<IDataManager, DataManager>();
            container.RegisterSingleton<IAuthenticationManager, AuthenticationManager>();
            return container;
        }
    }
}