using crispy_winner.Domain.Entities;
using crispy_winner.infrastructure.context;

namespace FinancialApi.Domain.Services;
using FinancialApi.Domain.Interfaces;

public class FinancialsService
{
    private readonly IUserRepository _repository;
    private readonly IBudgetRespository _budgetRespository;
    private readonly ICategoriesRepository _categoriesRepository;
    private readonly ITransactionsRepository _transactionsRespository;
   
    //private readonly ILogger<UsersService> _logger;
    
    public FinancialsService(IUserRepository repository, IBudgetRespository budgetRespository, ICategoriesRepository categoriesRepository)
    {
        _repository = repository;
        _budgetRespository = budgetRespository;
        _categoriesRepository = categoriesRepository;
        
       

    }
    
    
    public async Task<IEnumerable<Users>> GetAllUsers() => await _repository.GetAllUsers();

    public async Task<IEnumerable<Budget>> GetAllBudgets()
    {
        var budgets = await _budgetRespository.GetAllBudgets();
        return budgets;
        
    }

    public async Task<IEnumerable<Categories>> GetAllCategories()
    {
        var categories = await _categoriesRepository.GetAllCategories();
        return categories;
    }
   
   
    public async Task<Budget> GetBudgetById(Guid budgetId) => await _budgetRespository.GetBudgetById(budgetId); 
    public async Task<Categories> GetCategoryById(Guid categoryId) => await _categoriesRepository.GetCategoryById(categoryId);
    public async Task<Users> GetUserById(Guid userId) => await _repository.GetUserById(userId);
    
    
    public async Task AddUsers(Users users) => await _repository.AddUser(users);
    public async Task AddBudget(Budget budget) => await _budgetRespository.AddBudget(budget);
    public async Task AddCategory(Categories categories) => await _categoriesRepository.AddCategory(categories);
    
    
    public async Task UpdateUsers(Users users) => await _repository.UpdateUser(users);
    public async Task UpdateCategory(Categories categories) => await _categoriesRepository.UpdateCategory(categories);
    public async Task UpdateBudget(Budget budget) => await _budgetRespository.UpdateBudget(budget);
    
    
    
    public async Task DeleteUsers(Guid userId) => await _repository.DeleteUser(userId);
    public async Task DeleteCategory(Guid categorieId) => await _categoriesRepository.DeleteCategory(categorieId);
    public async Task DeleteBudget(Guid budgetId) => await _budgetRespository.DeleteBudget(budgetId);
    
    

}
