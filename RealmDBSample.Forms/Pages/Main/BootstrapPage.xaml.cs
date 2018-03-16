using System;
using RealmDBSample.Core;
using RealmDBSample.UI.ViewModels.Main;
using Xamarin.Forms.Xaml;

namespace RealmDBSample.Forms.Pages.Main
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BootstrapPage
    {
        private readonly IBootstrapViewModel _viewModel;
        private readonly IDependencyContainer _container;

        public BootstrapPage(IBootstrapViewModel viewModel, IDependencyContainer container)
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

        protected override void OnDisappearing()
        {
            base.OnAppearing();
        }

        private void ViewModelOnDidCompleteBootstrap(object sender, EventArgs eventArgs)
        {
        }
    }
}