using System;
using System.Collections.Generic;
using System.Windows.Input;
using PropertyChanged;
using RealmDBSample.Core.Managers;
using RealmDBSample.Core.Models;
using RealmDBSample.UI.Services;
using RealmDBSample.UI.ViewModels.Base;
using RealmDBSample.UI.ViewModels.Base.Implementation;

namespace RealmDBSample.UI.ViewModels.Store.Implementation
{
    [AddINotifyPropertyChangedInterface]
    internal class ProductViewModel : BaseLoadableViewModel, IProductViewModel, IInternalSaveableViewModel
    {
        public ProductViewModel(IDataManager dataManager, IDialogService dialogService)
        {
            LoadCommand = new LoadProductCommand(this, dataManager);
            SaveCommand = new SaveProductCommand(this, dataManager, dialogService);
            DeleteCommand = new DeleteProductCommand(this, dataManager);
        }

        public bool IsSaving { get; set; }
        public IAsyncCommand SaveCommand { get; }
        public bool DidSave { get; set; }
        public string SavingFailureMessage { get; set; }
        public ICommand DeleteCommand { get; }
        public string ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public IEnumerable<Category> Categories { get; internal set; }
        public Category SelectedCategory { get; set; }
        public Action DidChange { get; set; }
        internal Product Product { get; set; }
    }
}