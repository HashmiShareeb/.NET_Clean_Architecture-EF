using crispy_winner.Domain.Entities;
using FinancialApi.Domain.Interfaces;

namespace FinancialApi.Applications;

public class BudgetService
{
    private readonly IBudgetRespository _budgetRespository;

    public BudgetService(IBudgetRespository budgetRespository)
    {
        _budgetRespository = budgetRespository;
    }
    
    public async Task<Budget> GetBudgetById(Guid budgetId) => await _budgetRespository.GetBudgetById(budgetId); 
    
    public async Task AddBudget(Budget budget) => await _budgetRespository.AddBudget(budget);
    
    public async Task UpdateBudget(Budget budget) => await _budgetRespository.UpdateBudget(budget);
    
    public async Task DeleteBudget(Guid budgetId) => await _budgetRespository.DeleteBudget(budgetId);

}