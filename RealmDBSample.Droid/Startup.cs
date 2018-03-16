using Grace.DependencyInjection;
using RealmDBSample.Core;
using RealmDBSample.Core.Services;
using RealmDBSample.Droid.Services;
using RealmDBSample.Forms;
using RealmDBSample.UI;
using RealmDBSample.UI.Services;

namespace RealmDBSample.Droid
{
    public static class Startup
    {
        public static IDependencyContainer SetupContainer()
        {
            var graceContainer = new DependencyInjectionContainer();
            var container = new DependencyContainer(graceContainer);
            graceContainer.Add(block => block.ExportInstance(container).As<IDependencyContainer>());
            container.RegisterCoreDependencies()
                     .RegisterUIDependencies()
                     .RegisterFormsDependencies()
                     .RegisterDroidDependencies();
            ServiceLocator.Create(container);
            return container;
        }

        public static IDependencyContainer RegisterDroidDependencies(this IDependencyContainer container)
        {
            container.Register<IDatabaseInstallationService, DatabaseInstallationService>();
            return container;
        }
    }
}