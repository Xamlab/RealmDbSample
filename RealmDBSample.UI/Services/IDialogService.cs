using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RealmDBSample.UI.Services
{
    public interface IDialogService
    {
        void SetRootPage(object rootPage);
        Task ShowNotificationAsync(string message, string cancelText = "OK", string title = null);
        Task<bool> ShowConfirmationDialogAsync(string message, string confirmText, string cancelText);
        Task<bool> ShowConfirmationDialogAsync(string title, string message, string confirmText, string cancelText);
    }
}
