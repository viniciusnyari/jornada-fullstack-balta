using System.ComponentModel.DataAnnotations;
using Fina.Shared.Enums;

namespace Fina.Shared.Requests.Transactions;

public class CreateTransactionRequest : Request
{
    [Required(ErrorMessage = "O título da transação é obrigatório")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "O tipo da transação é obrigatório")]
    public ETransactionType Type { get; set; } = ETransactionType.Withdraw;
    
    [Required(ErrorMessage = "O valor da transação é obrigatório")]
    public decimal Amount { get; set; }
    
    [Required(ErrorMessage = "O identificador da categoria da transação é obrigatório")]
    public long CategoryId { get; set; }
    
    [Required(ErrorMessage = "A data da transação é obrigatório")]
    public DateTime? PaidOrReceivedAt { get; set; }
}