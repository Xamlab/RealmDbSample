using System;
using System.Threading.Tasks;
using RealmDBSample.UI.Services;
using Xamarin.Forms;

namespace RealmDBSample.Forms.Services.Implementation
{
    internal class DialogService : IDialogService
    {
        private Page _rootPage;

        public void SetRootPage(object rootPage)
        {
            _rootPage = rootPage as Page ?? throw new ArgumentNullException(nameof(rootPage));
            if(_rootPage == null) throw new InvalidOperationException($"{rootPage} parameter must be of type {typeof(Page).FullName}");
        }

        public Task ShowNotificationAsync(string message, string cancelText = "OK", string title = null)
        {
            if(_rootPage == null) throw new InvalidOperationException($"You must call {nameof(SetRootPage)} before using this method.");
            return _rootPage.DisplayAlert(title ?? string.Empty, message, cancelText);
        }

        public Task<bool> ShowConfirmationDialogAsync(string message, string confirmText, string cancelText)
        {
            return ShowConfirmationDialogAsync(string.Empty, message, confirmText, cancelText);
        }

        public Task<bool> ShowConfirmationDialogAsync(string title, string message, string confirmText, string cancelText)
        {
            if(_rootPage == null) throw new InvalidOperationException($"You must call {nameof(SetRootPage)} before using this method.");
            return _rootPage.DisplayAlert(title, message, confirmText, cancelText);
        }
    }
}