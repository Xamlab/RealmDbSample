using RealmDBSample.Core;
using RealmDBSample.Core.Services;
using RealmDBSample.Forms.Services.Implementation;
using RealmDBSample.UI.Services;

namespace RealmDBSample.Forms
{
    public static class Startup
    {
        public static IDependencyContainer RegisterFormsDependencies(this IDependencyContainer container)
        {
            container.RegisterSingleton<IDialogService, DialogService>();
            container.RegisterSingleton<INavigationService, NavigationService>();
            container.Register<IAuthenticationService, AuthenticationService>();

            return container;
        }
    }
}