using System;
using System.Collections.Generic;
using System.Windows.Input;
using RealmDBSample.Core.Models;
using RealmDBSample.UI.ViewModels.Base;

namespace RealmDBSample.UI.ViewModels.Store
{
    public interface IProductViewModel : ISaveableViewModel, ILoadableViewModel
    {
        ICommand DeleteCommand { get; }
        string ProductId { get; set; }
        string Name { get; set; }
        double Price { get; set; }
        IEnumerable<Category> Categories { get; }
        Category SelectedCategory { get; set; }
        Action DidChange { get; set; }
    }
}