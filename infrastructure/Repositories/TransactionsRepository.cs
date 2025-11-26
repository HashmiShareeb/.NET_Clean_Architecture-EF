using crispy_winner.Domain.Entities;
using crispy_winner.infrastructure.context;
using FinancialApi.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinancialApi.infrastructure.Repositories;

public class TransactionsRepository : ITransactionsRepository
{
    
    private readonly ApplicationContext _context;
    
    public TransactionsRepository(ApplicationContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Transaction>> GetAllTransactions()
    {
        return await _context.Transactions.ToListAsync();
    }

    public async Task<Transaction> GetTransactionsById(Guid transactionId)
    {
        return await _context.Transactions.FindAsync(transactionId);
    }

    public async Task<IEnumerable<Transaction>> GetUserTransactions(Guid userId)
        => await _context.Transactions
            .Where(t => t.UserId == userId)
            .ToListAsync();

    public async Task<Transaction> AddTransactions(Transaction transaction)
    {
        await _context.Transactions.AddAsync(transaction);
        await _context.SaveChangesAsync();
        return transaction;
    }
    
    public async Task UpdateTransactions(Transaction transaction)
    {
        _context.Update(transaction);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteTransactions(Guid transactionId)
    {
        _context.Remove(transactionId);
        await _context.SaveChangesAsync();
    }
}