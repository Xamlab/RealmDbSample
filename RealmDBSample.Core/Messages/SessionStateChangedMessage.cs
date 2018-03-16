using RealmDBSample.Core.Managers;

namespace RealmDBSample.Core.Messages
{
    public class SessionStateChangedMessage
    {
        public SessionStateChangedMessage(SessionState state)
        {
            State = state;
        }

        public SessionState State { get; set; }
    }
}
