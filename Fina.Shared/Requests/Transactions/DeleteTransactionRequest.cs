using System.ComponentModel.DataAnnotations;

namespace Fina.Shared.Requests.Transactions;

public class DeleteTransactionRequest : Request
{
    [Required(ErrorMessage = "O identificador é obrigatório para deletar a transação")]
    public long Id { get; set; }
}