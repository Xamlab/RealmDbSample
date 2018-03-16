using System.Windows.Input;

namespace RealmDBSample.UI.ViewModels.Base
{
    public interface IViewModelRequiresSetup
    {
        ICommand SetupCommand { get; }
    }
}