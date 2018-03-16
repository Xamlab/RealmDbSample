using System;
using System.Threading.Tasks;
using RealmDBSample.UI.ViewModels.Authentication;
using Xamarin.Forms.Xaml;

namespace RealmDBSample.Forms.Pages.Authentication
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LogInPage
    {
        private TaskCompletionSource<bool> _logInTask;

        public LogInPage(ILogInViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
            viewModel.LogInCompleted += ViewModelOnLogInCompleted;
        }

        public Task LogInAsync()
        {
            _logInTask = new TaskCompletionSource<bool>();
            return _logInTask.Task;
        }

        private void ViewModelOnLogInCompleted(object sender, EventArgs eventArgs)
        {
            _logInTask.TrySetResult(true);
        }
    }
}