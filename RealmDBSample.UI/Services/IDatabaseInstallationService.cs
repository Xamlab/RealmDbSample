using System.Threading.Tasks;

namespace RealmDBSample.UI.Services
{
    public interface IDatabaseInstallationService
    {
        Task InstallDatabase(string path);
    }
}