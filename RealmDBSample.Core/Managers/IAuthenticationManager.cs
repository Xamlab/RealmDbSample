using System.Threading.Tasks;

namespace RealmDBSample.Core.Managers
{
    public enum SessionState
    {
        LoggedOut,
        LoggedIn
    }

    public interface IAuthenticationManager
    {
        SessionState State { get; }
        Task SignIn();
        void SignOut();
        void RestoreSession();
    }
}
