using crispy_winner.Domain.Entities;
using FinancialApi.Domain.Interfaces;

namespace FinancialApi.Applications;

public class TransactionsService
{
    
    private readonly ITransactionsRepository _transactionsRepository;
    private readonly  IUserRepository _userRepository;
    private readonly ICategoriesRepository _categoriesRepository;

    public TransactionsService(ITransactionsRepository transactionsRepository, IUserRepository userRepository, ICategoriesRepository categoriesRepository)
    {
        _transactionsRepository = transactionsRepository;
        _userRepository = userRepository;
        _categoriesRepository = categoriesRepository;
    }
    
    public async  Task<IEnumerable<Transaction>> GetAllTransactions() => await _transactionsRepository.GetAllTransactions();
    public async Task<IEnumerable<Transaction>> GetUserTransactions(Guid userId) => await _transactionsRepository.GetUserTransactions(userId);

    public async Task<Transaction> GetTransactionById(Guid transactionId) =>
        await _transactionsRepository.GetTransactionsById(transactionId);

    public async Task<Transaction> AddTransaction(Transaction transaction)
    {
        var user = await _userRepository.GetUserById(transaction.UserId);
        if (user == null)
            throw new Exception("User not found");

        var category = await _categoriesRepository.GetCategoryById(transaction.CategoryId);
        if (category == null)
            throw new Exception("Category not found");

        transaction.Date = DateTime.UtcNow;

        return await _transactionsRepository.AddTransactions(transaction);

    }

    public async Task UpdateTransaction(Transaction transaction) => await _transactionsRepository.UpdateTransactions(transaction);
    
    public async Task DeleteTransaction(Guid transactionId) => await _transactionsRepository.DeleteTransactions(transactionId);



}