using System.Text.Json.Serialization;

namespace Fina.Shared.Responses;

public class Response<TData>
{
    private int _code = Configuration.DefaultStatusCodeSuccess;

    [JsonConstructor]
    public Response()
        => _code = Configuration.DefaultStatusCodeSuccess;
    public Response(TData? data, int code = Configuration.DefaultStatusCodeSuccess, string? message = null)
    {
        Data = data;
        Message = message;
        _code = code;
    }
    public TData? Data { get; set; }
    public string? Message { get; set; }

    [JsonIgnore]
    public bool IsSuccess => _code is >= Configuration.DefaultStatusCodeSuccess 
        or Configuration.DefaultStatusCodeSuccessFinal 
        or Configuration.DefaultStatusCodeSuccessFullCreated;
}