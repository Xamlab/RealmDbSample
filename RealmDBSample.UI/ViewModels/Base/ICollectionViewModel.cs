using System.Collections.Generic;

namespace RealmDBSample.UI.ViewModels.Base
{
    public interface ICollectionViewModel<out T> : ILoadableViewModel
    {
        IEnumerable<T> Items { get; }
    }
}