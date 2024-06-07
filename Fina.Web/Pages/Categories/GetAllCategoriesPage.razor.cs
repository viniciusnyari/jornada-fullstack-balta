using Fina.Shared.Handler;
using Fina.Shared.Models;
using Fina.Shared.Requests.Categories;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Fina.Web.Pages.Categories;

public partial class GetAllCategoriesPage : ComponentBase
{
    public bool IsBusy { get; set; }
    
    public List<Category> Categories { get; set; } = [];

    [Inject] 
    public ICategoryHandler Handler { get; set; } = null!;
    
    [Inject] 
    public ISnackbar SnackBar { get; set; } = null!;
    
    [Inject] 
    public IDialogService Dialog { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        IsBusy = true;

        try
        {
            var request = new GetAllCategoriesRequest();
            var result = await Handler.GetAllAsync(request);

            if (result.IsSuccess)
                Categories = result.Data ?? [];
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
            $"Ao prosseguir a categoria '{title}' será removida. Deseja continuar?",
            yesText: "Excluir",
            cancelText: "Cancelar");

        if (result is true)
            await OnDeleteAsync(id, title);
        
        StateHasChanged();
    }

    public async Task OnDeleteAsync(long id, string title)
    {
        try
        {
            var request = new DeleteCategoryRequest()
            {
                Id = id
            };
            
            var result = await Handler.DeleteAsync(request);
            Categories.RemoveAll(r => r.Id == id);
            
            if (result.IsSuccess)
                SnackBar.Add($"Categoria '{title}' foi excluída com sucesso!", Severity.Info);
        }
        catch (Exception e)
        {
            SnackBar.Add(e.Message, Severity.Error);
        }
    }
}