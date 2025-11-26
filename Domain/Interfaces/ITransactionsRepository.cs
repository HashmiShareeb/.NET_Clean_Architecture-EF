using crispy_winner.Domain.Entities;

namespace FinancialApi.Domain.Interfaces;

public interface ITransactionsRepository
{
    Task<IEnumerable<Transaction>> GetAllTransactions();
    Task<Transaction> GetTransactionsById(Guid transactionId);
    Task<IEnumerable<Transaction>> GetUserTransactions(Guid userId);
    Task<Transaction> AddTransactions(Transaction  transaction);
    Task UpdateTransactions(Transaction transaction);
    Task DeleteTransactions(Guid transactionId);
}