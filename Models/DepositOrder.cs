using System;

namespace ModernFI.Models;

public class DepositOrder
{
    public DateTime OrderDate { get; set; }
    public string Term { get; set; } = "";
    public decimal Amount { get; set; }
    public decimal Rate { get; set; }
    public decimal ProjectedBalance { get; set; }
}
