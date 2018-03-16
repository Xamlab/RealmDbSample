using PubSub;
using RealmDBSample.Core;
using RealmDBSample.Core.Managers;
using RealmDBSample.Core.Messages;
using RealmDBSample.Forms.Pages.Main;
using RealmDBSample.Forms.Services;
using RealmDBSample.UI.Services;
using Xamarin.Forms;

namespace RealmDBSample.Forms
{
    public partial class App
    {
        private readonly IDependencyContainer _container;

        public static App Instance { get; private set; }
        public App(IDependencyContainer container)
        {
            _container = container;
            Instance = this;
            InitializeComponent();

            
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            var authManager = _container.Resolve<IAuthenticationManager>();
            var navigationService = _container.Resolve<INavigationService>();
            authManager.RestoreSession();
            if (authManager.State == SessionState.LoggedIn)
            {
                navigationService.ShowBootstrapPage();
            }
            else
            {
                authManager.SignIn();
            }

            this.Subscribe<SessionStateChangedMessage>(OnSessionStateChanged);
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        private void OnSessionStateChanged(SessionStateChangedMessage message)
        {
            if (message.State == SessionState.LoggedIn)
            {
                _container.Resolve<INavigationService>().ShowBootstrapPage();
            }
        }
    }
}