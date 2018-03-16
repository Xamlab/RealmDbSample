using System;
using System.Diagnostics;
using System.Threading.Tasks;
using PubSub;
using RealmDBSample.Core.Messages;
using RealmDBSample.Core.Services;
using Realms.Sync;

namespace RealmDBSample.Core.Managers.Implementation
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private SessionState _state;
        private readonly IAuthenticationService _authService;
        private Task _signInTask;
        private readonly object _signInLocker = new object();
        private readonly object _restoreLocker = new object();

        public AuthenticationManager(IAuthenticationService authService)
        {
            _authService = authService;
        }

        public SessionState State
        {
            get => _state;
            private set
            {
                if(_state != value)
                {
                    _state = value;
                    this.Publish(new SessionStateChangedMessage(_state));
                }
            }
        }

        public Task SignIn()
        {
            lock(_signInLocker)
            {
                if(_signInTask != null) return _signInTask;
                _signInTask = SignInInternal();
                return _signInTask;
            }
        }

        public async void SignOut()
        {
            await User.Current.LogOutAsync();
            State = SessionState.LoggedOut;
            await SignIn();
        }

        public void RestoreSession()
        {
            lock(_restoreLocker)
            {
                if(User.Current != null)
                {
                    State = SessionState.LoggedIn;
                }
                else
                {
                    State = SessionState.LoggedOut;
                }
            }
        }

        private async Task SignInInternal()
        {
            try
            {
                await _authService.Authenticate();

                if(User.Current != null)
                {
                    State = SessionState.LoggedIn;
                }
                else
                {
                    State = SessionState.LoggedOut;
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex);
                throw;
            }
            finally
            {
                _signInTask = null;
            }
        }
    }
}
