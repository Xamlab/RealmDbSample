using RealmDBSample.Core;
using RealmDBSample.UI.ViewModels.Store;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RealmDBSample.Forms.Pages.Store
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StoreListPage
    {
        private readonly IStoreListViewModel _viewModel;
        private readonly IDependencyContainer _container;

        public StoreListPage(IStoreListViewModel viewModel, IDependencyContainer container)
        {
            _container = container;
            _viewModel = viewModel;
            InitializeComponent();
            BindingContext = viewModel;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.LoadCommand.Execute(null);
        }

        private async void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem == null) return;
            if(e.SelectedItem is Core.Models.Store store)
            {
                var productPage = _container.Resolve<ProductListPage>();
                productPage.Initialize(store);
                await Navigation.PushAsync(productPage);
            }
        }
    }
}