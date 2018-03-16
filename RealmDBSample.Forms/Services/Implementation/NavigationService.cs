using System.Threading.Tasks;
using PubSub;
using RealmDBSample.Core;
using RealmDBSample.Core.Managers;
using RealmDBSample.Core.Messages;
using RealmDBSample.Forms.Pages.Authentication;
using RealmDBSample.Forms.Pages.Main;
using RealmDBSample.Forms.Pages.Store;
using RealmDBSample.UI.Services;
using Xamarin.Forms;

namespace RealmDBSample.Forms.Services.Implementation
{
    public class NavigationService : INavigationService
    {
        private readonly IDependencyContainer _container;
        private readonly App _app;
        private readonly IDialogService _dialogService;

        public NavigationService(IDialogService dialogService, IDependencyContainer container, App app)
        {
            _dialogService = dialogService;
            _app = app;
            _container = container;
        }

        public void ShowBootstrapPage()
        {
            ChangeMainPage(new NavigationPage(_container.Resolve<BootstrapPage>()));
        }

        public void ShowMainPage()
        {
            ChangeMainPage(new NavigationPage(_container.Resolve<StoreListPage>()));
        }

        public async Task StartLoginInUIFlowAsync()
        {
            var loginPage = _container.Resolve<LogInPage>();
            ChangeMainPage(loginPage);
            await loginPage.LogInAsync();
        }


        private void ChangeMainPage(Page page)
        {
            _app.MainPage = page;
            _dialogService.SetRootPage(page);
        }
    }
}
