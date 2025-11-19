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
    
    public async Task<Budget> GetBudgetById(Guid BudgetId)
    {
        return await _context.Budgets.FindAsync(BudgetId);
    }

    public async Task<Budget> AddBudget(Budget budget)
    {
        await _context.AddAsync(budget);
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
        _context.Remove(budgetId);
        await _context.SaveChangesAsync();
    }


    public async Task DeleteBudget(Budget budget)
    {
        _context.Remove(budget);
        await _context.SaveChangesAsync();
        
    }
    

    public async Task<IEnumerable<Budget>> GetAllBudgets()
    {
        return await _context.Budgets.ToListAsync();
    }

    public Task<Budget> GetBudget(Guid budgetId)
    {
        throw new NotImplementedException();
    }
}