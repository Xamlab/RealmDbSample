using System.Threading.Tasks;
using RealmDBSample.Core.Services;
using RealmDBSample.UI.Services;

namespace RealmDBSample.Forms.Services.Implementation
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly INavigationService _navigationService;

        public AuthenticationService(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public Task Authenticate()
        {
            return _navigationService.StartLoginInUIFlowAsync();
        }
    }
}
