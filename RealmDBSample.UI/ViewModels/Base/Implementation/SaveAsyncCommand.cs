using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using RealmDBSample.UI.Services;

namespace RealmDBSample.UI.ViewModels.Base.Implementation
{
    internal abstract class SaveAsyncCommand : AsyncCommand
    {
        private readonly IInternalSaveableViewModel _viewModel;
        private readonly IDialogService _dialogService;

        protected virtual string OperationUnknownFailureMessage => "Operation failed";
        protected virtual string OperationNetworkFailureMessage => "Operation failed";

        protected SaveAsyncCommand(IInternalSaveableViewModel viewModel, IDialogService dialogService)
        {
            _dialogService = dialogService;
            _viewModel = viewModel;
        }

        public override async Task ExecuteAsync(object param, CancellationToken token = default(CancellationToken))
        {
            SetCanExecute(false);
            _viewModel.SavingFailureMessage = null;

            try
            {
                if(await ShouldExecuteCore())
                {
                    _viewModel.IsSaving = true;
                    await ExecuteCoreAsync(param, token);
                    _viewModel.DidSave = true;
                }
            }
            catch(Exception ex)
            {
                if(!HandleException(ex, token)) throw;
            }
            finally
            {
                _viewModel.IsSaving = false;
                SetCanExecute(true);
            }
        }

        protected abstract Task ExecuteCoreAsync(object param, CancellationToken token = default(CancellationToken));

        protected virtual Task<bool> ShouldExecuteCore()
        {
            return Task.FromResult(true);
        }

        public virtual bool HandleException(Exception ex, CancellationToken token)
        {

            //Ignore operation cancellations
            if (ex is OperationCanceledException)
            {
                return true;
            }

            Debug.WriteLine(ex);
            if (ex is WebException)
            {
                Notify(OperationNetworkFailureMessage);
                return true;
            }

            Notify(OperationUnknownFailureMessage);
            return true;
        }

        private async void Notify(string message)
        {
            _viewModel.SavingFailureMessage = message;
            await _dialogService.ShowNotificationAsync(message, "ok");
        }
    }
}