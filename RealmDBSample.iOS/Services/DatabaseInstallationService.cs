using System.IO;
using System.Threading.Tasks;
using Foundation;
using RealmDBSample.UI.Services;

namespace RealmDBSample.iOS.Services
{
    public class DatabaseInstallationService : IDatabaseInstallationService
    {
        public async Task InstallDatabase(string path)
        {
            var dbPath = NSBundle.MainBundle.PathForResource("realmdbsample", "realm");
            var source = new FileInfo(dbPath);
            var target = new FileInfo(path);
            if(!target.Exists || source.Length != target.Length)
            {
                await Task.Factory.StartNew(() => { File.Copy(dbPath, path, true); });
            }
        }
    }
}