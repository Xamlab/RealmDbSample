namespace RealmDBSample.UI.ViewModels.Base
{
    public interface ISaveableViewModel
    {
        bool IsSaving { get; }
        IAsyncCommand SaveCommand { get; }
        bool DidSave { get; }
        string SavingFailureMessage { get; }
    }
}