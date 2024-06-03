﻿using Fina.Shared.Enums;

namespace Fina.Shared.Models;

public class Transaction
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? PaidOrReceivedAt { get; set; }

    public ETransactionType Type { get; set; } = ETransactionType.Withdraw;
    
    public long CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    
    public string UserId { get; set; } = string.Empty;
}