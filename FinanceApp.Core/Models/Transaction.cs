using FinanceApp.Core.Enum;

namespace FinanceApp.Core.Models;

public class Transaction
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? PaidOrReceivedAt { get; set; }
    public ETransactionType Type { get; set; } = ETransactionType.Withdraw;
    
    public long CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    
    public string UserId { get; set; } = string.Empty;
}