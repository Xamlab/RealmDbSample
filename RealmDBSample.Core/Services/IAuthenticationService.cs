using System.Threading.Tasks;

namespace RealmDBSample.Core.Services
{
    public interface IAuthenticationService
    {
        Task Authenticate();
    }
}
