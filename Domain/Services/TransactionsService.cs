using crispy_winner.Domain.Entities;
using FinancialApi.Domain.Interfaces;

namespace FinancialApi.Applications;

public class TransactionsService
{
    
    private readonly ITransactionsRepository _transactionsRepository;

    public TransactionsService(ITransactionsRepository transactionsRepository)
    {
        _transactionsRepository = transactionsRepository;
    }
    
    public async  Task<IEnumerable<Transaction>> GetAllTransactions() => await _transactionsRepository.GetAllTransactions();

    public async Task<Transaction> GetTransactionById(Guid transactionId) =>
        await _transactionsRepository.GetTransactionsById(transactionId);
    
    public async Task UpdateTransaction(Transaction transaction) => await _transactionsRepository.UpdateTransactions(transaction);
    
    public async Task DeleteTransaction(Guid transactionId) => await _transactionsRepository.DeleteTransactions(transactionId);



}