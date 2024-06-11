using System.Net.Http.Json;
using Fina.Shared;
using Fina.Shared.Handler;
using Fina.Shared.Models;
using Fina.Shared.Requests.Transactions;
using Fina.Shared.Responses;

namespace Fina.Web.Handlers;

public class TransactionHandler(IHttpClientFactory httpClientFactory) : ITransactionHandler
{
    private readonly HttpClient _client = httpClientFactory.CreateClient(WebConfiguration.HttpClientName);
    public async Task<Response<Transaction?>> CreateAsync(CreateTransactionRequest request)
    {
        var result = await _client.PostAsJsonAsync("v1/transacoes", request);
        
        return await result.Content.ReadFromJsonAsync<Response<Transaction?>>()
               ?? new Response<Transaction?>(null, Configuration.DefaultStatusCodeNotFound, "Falha ao criar a transação");
    }

    public async Task<Response<Transaction?>> UpdateAsync(UpdateTransactionRequest request)
    {
        var result = await _client.PutAsJsonAsync($"v1/transacoes/{request.Id}", request);
        
        return await result.Content.ReadFromJsonAsync<Response<Transaction?>>()
               ?? new Response<Transaction?>(null, Configuration.DefaultStatusCodeNotFound, "Falha ao atualizar a transação");
    }

    public async Task<Response<Transaction?>> DeleteAsync(DeleteTransactionRequest request)
    {
        var result = await _client.DeleteAsync($"v1/transacoes/{request.Id}");
        
        return await result.Content.ReadFromJsonAsync<Response<Transaction?>>()
               ?? new Response<Transaction?>(null, Configuration.DefaultStatusCodeNotFound, "Falha ao deletar a transação");
    }

    public async Task<Response<Transaction?>> GetByIdAsync(GetTransactionByIdRequest request)
        => await _client.GetFromJsonAsync<Response<Transaction?>>($"v1/transacoes/{request.Id}")
           ?? new Response<Transaction?>(null, Configuration.DefaultStatusCodeNotFound, "Falha ao obter a transação");

    public async Task<PagedResponse<List<Transaction>?>> GetByPeriodAsync(GetTransactionsByPeriodRequest request)
        => await _client.GetFromJsonAsync<PagedResponse<List<Transaction>?>>($"v1/transacoes")
           ?? new PagedResponse<List<Transaction>?>(null, Configuration.DefaultStatusCodeNotFound, "Falha ao obter a transação");
}