using Fina.Shared.Handler;
using Fina.Shared.Requests.Categories;
using Fina.Shared.Requests.Transactions;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Fina.Web.Pages.Transactions;

public partial class CreateTransactionPage : ComponentBase
{
    public bool IsBusy { get; set; }
    
    public CreateTransactionRequest InputModel { get; set; } = new();

    [Inject] 
    public ITransactionHandler Handler { get; set; } = null!;
    
    [Inject] 
    public NavigationManager NavigationManager { get; set; } = null!;
    
    [Inject] 
    public ISnackbar SnackBar { get; set; } = null!;

    public async Task OnValidSubmitAsync()
    {
        IsBusy = true;

        try
        {
            var result = await Handler.CreateAsync(InputModel);

            if (result.IsSuccess)
            {
                SnackBar.Add(result.Message, Severity.Success);
                NavigationManager.NavigateTo("/transacoes");
            }
            else
                SnackBar.Add(result.Message, Severity.Error);
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
}