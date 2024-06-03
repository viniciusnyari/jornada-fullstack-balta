namespace Fina.Shared.Requests;

/// <summary>
/// Essa será a classe base de requisições
/// </summary>
public abstract class Request
{
    public string UserId { get; set; } = string.Empty;
}