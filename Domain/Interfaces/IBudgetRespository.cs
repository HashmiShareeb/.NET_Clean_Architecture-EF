using crispy_winner.Domain.Entities;

namespace FinancialApi.Domain.Interfaces;

//entities without DTO's just pure domain Entity
public interface IBudgetRespository
{
    Task<IEnumerable<Budget>> GetAllBudgets();
    Task<Budget?> GetBudgetWithTransactions(Guid budgetId);
    Task<Budget> GetBudgetById(Guid budgetId);
    Task <Budget>AddBudget(Budget budget);
    Task UpdateBudget(Budget budget);
    Task DeleteBudget(Guid budgetId);
    Task <Budget?> GetBudgetByUser(Guid userId, Guid categoryId, DateTime month );

}