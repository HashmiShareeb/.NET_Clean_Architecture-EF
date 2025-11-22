using crispy_winner.Domain.Entities;
using FinancialApi.Applications.DTO;
using FinancialApi.Domain.Interfaces; 
namespace FinancialApi.Applications;

public class BudgetService
{
    private readonly IBudgetRespository _budgetRespository;
    private readonly ITransactionsRepository _transactionsRespository;

    public BudgetService(IBudgetRespository budgetRespository, ITransactionsRepository transactionsRespository)
    {
        _budgetRespository = budgetRespository;
        _transactionsRespository = transactionsRespository;
    }
    
    public async Task<Budget> GetBudgetById(Guid budgetId) => await _budgetRespository.GetBudgetById(budgetId); 
    
    public async Task AddBudget(Budget budget) => await _budgetRespository.AddBudget(budget);
    
    public async Task UpdateBudget(Budget budget) => await _budgetRespository.UpdateBudget(budget);
    
    public async Task DeleteBudget(Guid budgetId) => await _budgetRespository.DeleteBudget(budgetId);

    public async Task<BudgetDTO> GetBudgetStatus(Guid budgetId)
    {
        var budget = await _budgetRespository.GetBudgetWithTransactions(budgetId);
    
        if (budget == null)
            throw new Exception("Budget not found");

        return new BudgetDTO
        {
            BudgetId = budget.BudgetId,
            CategoryId = budget.CategoryId,
            AllocatedAmount = budget.Amount,
            Month = budget.Month,
            TotalSpent = budget.TotalSpent,
            RemainingAmount = budget.RemainingAmount,
            PercentUsed = budget.PercentUsed,
            IsExceeded = budget.IsExceeded
        };
    }
    
}