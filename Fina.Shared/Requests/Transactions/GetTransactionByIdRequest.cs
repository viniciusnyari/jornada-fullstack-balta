using System.ComponentModel.DataAnnotations;

namespace Fina.Shared.Requests.Transactions;

public class GetTransactionByIdRequest : Request
{
    [Required(ErrorMessage = "O identificador é obrigatório para obter a transação")]
    public long Id { get; set; }
}