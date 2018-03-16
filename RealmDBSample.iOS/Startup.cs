using Grace.DependencyInjection;
using RealmDBSample.Core;
using RealmDBSample.Forms;
using RealmDBSample.iOS.Services;
using RealmDBSample.UI;
using RealmDBSample.UI.Services;

namespace RealmDBSample.iOS
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
                     .RegisteriOSDependencies();
            ServiceLocator.Create(container);
            return container;
        }

        public static IDependencyContainer RegisteriOSDependencies(this IDependencyContainer container)
        {
            container.Register<IDatabaseInstallationService, DatabaseInstallationService>();
            return container;
        }
    }
}