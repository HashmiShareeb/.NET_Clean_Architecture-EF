namespace FinancialApi.Applications.DTO;

public class BudgetDTO
{
    public Guid BudgetId { get; set; }
    public Guid CategoryId { get; set; }
    public Guid UserId { get; set; }
    public decimal AllocatedAmount { get; set; } // Renamed for clarity
    public DateTime Month { get; set; }

    // Properties derived from calculation (Business Logic Results)
    public decimal TotalSpent { get; set; }
    public decimal RemainingAmount { get; set; }
    public decimal PercentUsed { get; set; }
    public bool IsExceeded { get; set; }
    
}

