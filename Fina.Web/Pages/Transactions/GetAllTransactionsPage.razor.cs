using Fina.Shared.Handler;
using Fina.Shared.Models;
using Fina.Shared.Requests.Transactions;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Fina.Web.Pages.Transactions;

public partial class GetAllTransactionsPage : ComponentBase
{
    public bool IsBusy { get; set; }
    
    public List<Transaction> Transactions { get; set; } = [];

    [Inject] 
    public ITransactionHandler Handler { get; set; } = null!;
    
    [Inject] 
    public ISnackbar SnackBar { get; set; } = null!;
    
    [Inject] 
    public IDialogService Dialog { get; set; } = null!;
    
    [Inject] 
    public NavigationManager NavigationManager { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        IsBusy = true;

        try
        {
            // var request = new GetAllCategoriesRequest();
            // var result = await Handler.GetByPeriodAsync(request);
            //
            // if (result.IsSuccess)
            //     Transactions = result.Data ?? [];
            Transactions = [];
        }
        catch (Exception e)
        {
            SnackBar.Add(e.Message, Severity.Error);
        }
        finally
        {
            IsBusy = false;
        }
    }

    public async void OnDeleteButtonClickedAsync(long id, string title)
    {
        var result = await Dialog.ShowMessageBox(
            "ATENÇÃO",
            $"Ao prosseguir a transação '{title}' será removida. Deseja continuar?",
            yesText: "Excluir",
            cancelText: "Cancelar");

        if (result is true)
            await OnDeleteAsync(id, title);
        
        StateHasChanged();
    }
    
    public void OnUpdateButtonClickedAsync(long id)
    {
        NavigationManager.NavigateTo($"/transacoes/alterar/{id}");
    }

    public async Task OnDeleteAsync(long id, string title)
    {
        try
        {
            var request = new DeleteTransactionRequest()
            {
                Id = id
            };
            
            var result = await Handler.DeleteAsync(request);
            Transactions.RemoveAll(r => r.Id == id);
            
            if (result.IsSuccess)
                SnackBar.Add($"Transação '{title}' foi excluída com sucesso!", Severity.Info);
        }
        catch (Exception e)
        {
            SnackBar.Add(e.Message, Severity.Error);
        }
    }
}