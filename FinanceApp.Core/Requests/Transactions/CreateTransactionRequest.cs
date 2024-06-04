using System.ComponentModel.DataAnnotations;
using FinanceApp.Core.Enum;

namespace FinanceApp.Core.Requests.Transactions;

public class CreateTransactionRequest : Request
{
    [Required(ErrorMessage = "Título inválido")]
    [MaxLength(80, ErrorMessage = "Título deve ter no máximo {0} caracteres")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Tipo inválido")]
    public ETransactionType Type { get; set; } = ETransactionType.Withdraw;

    [Required(ErrorMessage = "Valor inválido")]
    public decimal Amount { get; set; }

    [Required(ErrorMessage = "Categoria inválida")]
    public long CategoryId { get; set; }

    [Required(ErrorMessage = "Data inválida")]
    public DateTime PaidOrReceivedAt { get; set; }
}