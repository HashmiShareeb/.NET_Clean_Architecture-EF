using crispy_winner.Domain.Entities;
using FinancialApi.Applications.DTO;
using FinancialApi.Domain.Interfaces; 
namespace FinancialApi.Applications;

public class BudgetService
{
    private readonly IBudgetRespository _budgetRepository;
    private readonly ITransactionsRepository _transactionsRespository;
    private readonly IUserRepository _userRepository;

    public BudgetService(IBudgetRespository  budgetRepository, ITransactionsRepository transactionsRespository, IUserRepository userRepository)
    {
        _budgetRepository = budgetRepository;
        _transactionsRespository = transactionsRespository;
        _userRepository = userRepository;
    }
    
    public async Task<Budget> GetBudgetById(Guid budgetId) => await  _budgetRepository.GetBudgetById(budgetId);

    public async Task<Budget> AddBudget(CreateBudgetDTO dto)
    {
        // 1. Validate user exists
        var user = await _userRepository.GetUserById(dto.UserId);
        if (user == null)
            throw new Exception("User not found");

        // 2. Validate no duplicate budget
        var existing = await _budgetRepository.GetBudgetByUser(
            dto.UserId, dto.CategoryId, dto.Month);

        if (existing != null)
            throw new Exception("Budget already exists for this month & category");

        // 3. Create Budget entity
        var budget = new Budget
        {
            BudgetId = Guid.NewGuid(),
            UserId = dto.UserId,
            CategoryId = dto.CategoryId,
            Amount = dto.AllocatedAmount,
            Month = dto.Month
        };

        // 4. Save
        return await _budgetRepository.AddBudget(budget);
    }

    
    public async Task UpdateBudget(Budget budget) => await  _budgetRepository.UpdateBudget(budget);
    
    public async Task DeleteBudget(Guid budgetId) => await  _budgetRepository.DeleteBudget(budgetId);

    public async Task<BudgetDTO> GetBudgetStatus(Guid budgetId)
    {
        var budget = await  _budgetRepository.GetBudgetWithTransactions(budgetId);
    
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