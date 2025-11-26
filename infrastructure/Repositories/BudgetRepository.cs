using crispy_winner.Domain.Entities;
using crispy_winner.infrastructure.context;
using FinancialApi.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinancialApi.infrastructure.Repositories;

public class BudgetRepository : IBudgetRespository
{
    private readonly ApplicationContext _context;

    public BudgetRepository(ApplicationContext context)
    {
        _context = context;
    }
    
    public async Task<Budget> GetBudgetById(Guid budgetId)
    {
        return await _context.Budgets.FindAsync(budgetId);
    }

    public async Task <Budget>AddBudget(Budget budget){
        await _context.Budgets.AddAsync(budget);
        await _context.SaveChangesAsync();
        return budget;
    }


    public async Task UpdateBudget(Budget budget)
    {
        _context.Update(budget);
        await _context.SaveChangesAsync();
        
    }

    public async Task DeleteBudget(Guid budgetId)
    {
        var budget = await _context.Budgets.FindAsync(budgetId);
        if (budget != null)
        {
            _context.Budgets.Remove(budget);
            await _context.SaveChangesAsync();
        }
    }

    public Task<Budget?> GetBudgetByUser(Guid userId, Guid categoryId, DateTime month)
    {
        var budget = _context.Budgets;
        return budget.Where(b => b.UserId == userId && b.CategoryId == categoryId && b.Month == month).FirstOrDefaultAsync();
        
    }

    public async Task<IEnumerable<Budget>> GetAllBudgets()
    {
        return await _context.Budgets.ToListAsync();
    }
    
    //? --> possible null
    public async Task<Budget?> GetBudgetWithTransactions(Guid budgetId)
    {
        return await _context.Budgets
            .Include(b => b.Transactions)
            .FirstOrDefaultAsync(b => b.BudgetId == budgetId);
    }
}