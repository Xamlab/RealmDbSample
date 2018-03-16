using System.Collections.Generic;

namespace RealmDBSample.UI.ViewModels.Base
{
    internal interface IInternalCollectionViewModel<T> : ICollectionViewModel<T>
    {
        new IEnumerable<T> Items { get; set; }
    }
}