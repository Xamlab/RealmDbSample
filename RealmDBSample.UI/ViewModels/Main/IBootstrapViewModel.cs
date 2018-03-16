using System;
using RealmDBSample.UI.ViewModels.Base;

namespace RealmDBSample.UI.ViewModels.Main
{
    public interface IBootstrapViewModel : ILoadableViewModel
    {
        string Progress { get; }
    }
}