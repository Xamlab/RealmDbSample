using RealmDBSample.Core;
using RealmDBSample.Core.Models;
using RealmDBSample.UI.ViewModels.Store;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RealmDBSample.Forms.Pages.Store
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductListPage 
    {
        private readonly IProductListViewModel _viewModel;
        private readonly IDependencyContainer _container;

        public ProductListPage(IProductListViewModel viewModel, IDependencyContainer container)
        {
            _container = container;
            _viewModel = viewModel;
            InitializeComponent();
            BindingContext = viewModel;
        }

        public void Initialize(Core.Models.Store store)
        {
            _viewModel.Store = store;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.LoadCommand.Execute(null);
        }

        private async void ListView_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem is Product product)
            {
                var productPage = _container.Resolve<ProductPage>();
                productPage.Initialize(product.Id);
                await Navigation.PushAsync(productPage);
            }

            //ListView.SelectedItem = null;
        }
    }
}