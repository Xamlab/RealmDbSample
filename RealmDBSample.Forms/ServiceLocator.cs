using RealmDBSample.Core;

namespace RealmDBSample.Forms
{
    public static class ServiceLocator
    {
        public static IDependencyContainer Instance { get; private set; }

        public static void Create(IDependencyContainer container)
        {
            Instance = container;
        }
    }
}