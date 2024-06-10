using AutoMapper;
using Fina.Shared.Handler;
using Fina.Shared.Models;
using Fina.Shared.Requests.Categories;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace Fina.Web.Pages.Categories;

public partial class UpdateCategoryPage : ComponentBase
{
    [Parameter]
    public long Id { get; set; }
    
    public bool IsBusy { get; set; }
    
    public UpdateCategoryRequest InputModel { get; set; } = new();

    [Inject] 
    public ICategoryHandler Handler { get; set; } = null!;
    
    [Inject] 
    public NavigationManager NavigationManager { get; set; } = null!;
    
    [Inject] 
    public ISnackbar SnackBar { get; set; } = null!;
    
    [Inject] 
    public IMapper Mapper { get; set; } = null!;
    
    protected override async Task OnParametersSetAsync()
    {
        if (Id > 0)
        {
            var request = new GetCategoryByIdRequest() { Id = Id };

            var response = await Handler.GetByIdAsync(request);
            
            if (!response.IsSuccess)
                SnackBar.Add("Categoria não encontrada", Severity.Error);

            InputModel = Mapper.Map<UpdateCategoryRequest>(response.Data);
        }
    }

    public async Task OnValidSubmitAsync()
    {
        IsBusy = true;

        try
        {
            var result = await Handler.UpdateAsync(InputModel);

            if (result.IsSuccess)
            {
                SnackBar.Add(result.Message, Severity.Success);
                NavigationManager.NavigateTo("/categorias");
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