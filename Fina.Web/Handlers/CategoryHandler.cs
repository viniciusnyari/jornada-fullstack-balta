using System.Net.Http.Json;
using Fina.Shared;
using Fina.Shared.Handler;
using Fina.Shared.Models;
using Fina.Shared.Requests.Categories;
using Fina.Shared.Responses;

namespace Fina.Web.Handlers;

public class CategoryHandler(IHttpClientFactory httpClientFactory) : ICategoryHandler
{
    private readonly HttpClient _client = httpClientFactory.CreateClient(WebConfiguration.HttpClientName);
    
    public async Task<Response<Category?>> CreateAsync(CreateCategoryRequest request)
    {
        var result = await _client.PostAsJsonAsync("v1/categories", request);
        
        return await result.Content.ReadFromJsonAsync<Response<Category?>>()
            ?? new Response<Category?>(null, Configuration.DefaultStatusCodeNotFound, "Falha ao criar a categoria");
    }

    public async Task<Response<Category?>> UpdateAsync(UpdateCategoryRequest request)
    {
        var result = await _client.PutAsJsonAsync($"v1/categories/{request.Id}", request);
        
        return await result.Content.ReadFromJsonAsync<Response<Category?>>()
               ?? new Response<Category?>(null, Configuration.DefaultStatusCodeNotFound, "Falha ao atualizar a categoria");
    }

    public async Task<Response<Category?>> DeleteAsync(DeleteCategoryRequest request)
    {
        var result = await _client.DeleteAsync($"v1/categories/{request.Id}");
        
        return await result.Content.ReadFromJsonAsync<Response<Category?>>()
               ?? new Response<Category?>(null, Configuration.DefaultStatusCodeNotFound, "Falha ao deletar a categoria");
    }

    public async Task<Response<Category?>> GetByIdAsync(GetCategoryByIdRequest request)
    => await _client.GetFromJsonAsync<Response<Category?>>($"v1/categories/{request.Id}")
               ?? new Response<Category?>(null, Configuration.DefaultStatusCodeNotFound, "Falha ao obter a categoria");

    public async Task<PagedResponse<List<Category>?>> GetAllAsync(GetAllCategoriesRequest request)
        => await _client.GetFromJsonAsync<PagedResponse<List<Category>?>>($"v1/categories")
           ?? new PagedResponse<List<Category>?>(null, Configuration.DefaultStatusCodeNotFound, "Falha ao obter a categoria");
}