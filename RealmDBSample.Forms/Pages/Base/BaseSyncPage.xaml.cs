using System;
using PubSub;
using RealmDBSample.Core.Managers.Implementation;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RealmDBSample.Forms.Pages.Base
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [ContentProperty(nameof(RootContent))]
    public partial class BaseSyncPage
    {
        public BaseSyncPage()
        {
            InitializeComponent();
        }

        public View RootContent
        {
            get => _rootContent.Content;
            set => _rootContent.Content = value;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.Subscribe<SyncProgress>(OnSync);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            this.Unsubscribe<SyncProgress>();
        }

        private void OnSync(SyncProgress syncProgress)
        {
            if(syncProgress.TotalTransferred < syncProgress.TotalTransferable)
            {
                _syncProgress.IsVisible = true;
                _syncProgress.Text = $"Synced {syncProgress.TotalTransferred / syncProgress.TotalTransferable:P}";
            }
            else
            {
                _syncProgress.IsVisible = false;
            }
        }
    }
}