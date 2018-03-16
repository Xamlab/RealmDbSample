using System.Threading.Tasks;

namespace RealmDBSample.UI.Services
{
    public interface INavigationService
    {
        void ShowBootstrapPage();
        void ShowMainPage();
        Task StartLoginInUIFlowAsync();
    }
}
