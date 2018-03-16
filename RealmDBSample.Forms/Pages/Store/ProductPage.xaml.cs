using RealmDBSample.UI.ViewModels.Store;
using Xamarin.Forms.Xaml;

namespace RealmDBSample.Forms.Pages.Store
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductPage
    {
        private readonly IProductViewModel _viewModel;

        public ProductPage(IProductViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = _viewModel = viewModel;
            _viewModel.DidChange = async () => await Navigation.PopAsync();
        }

        public void Initialize(string productId)
        {
            _viewModel.ProductId = productId;
            _viewModel.LoadCommand.Execute(null);
        }
    }
}