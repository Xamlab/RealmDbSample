using System.IO;
using System.Threading.Tasks;
using RealmDBSample.UI.Services;

namespace RealmDBSample.Droid.Services
{
    public class DatabaseInstallationService : IDatabaseInstallationService
    {
        public async Task InstallDatabase(string path)
        {
            //var dbFile = MainActivity.Instance.Resources.Assets.OpenFd("realmdbsample.realm");
            
            var target = new FileInfo(path);
            if(!target.Exists /*|| dbFile.Length != target.Length*/)
            {
                using(var sourceStream = MainActivity.Instance.Resources.Assets.Open("realmdbsample.realm"))
                {
                    using (var targetStream = File.Create(path))
                    {
                        await sourceStream.CopyToAsync(targetStream);
                    }
                }
            }
        }
    }
}