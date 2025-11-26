namespace FinancialApi.Applications.DTO;

public class CreateBudgetDTO
{
    public Guid UserId { get; set; }
    public Guid CategoryId { get; set; }
    public decimal AllocatedAmount { get; set; }
    public DateTime Month { get; set; }
}
