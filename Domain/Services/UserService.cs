using crispy_winner.Domain.Entities;
using FinancialApi.Domain.Interfaces;

namespace FinancialApi.Domain.Services;

public class UserService
{
    private readonly IUserRepository _repository;
    
    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }
    
    public async Task<IEnumerable<Users>> GetAllUsers() => await _repository.GetAllUsers();
    
    public async Task<Users?> GetUserById(Guid userId) => await _repository.GetUserById(userId);
    
    public async Task AddUser(Users users) => await _repository.AddUser(users);

    
}