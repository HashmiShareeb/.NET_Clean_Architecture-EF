using crispy_winner.Domain.Entities;

namespace FinancialApi.Domain.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<Users>> GetAllUsers();
    Task<Users> GetUserById(Guid userId);
    Task <Users>AddUser(Users user);
    Task UpdateUser(Users user);
    Task DeleteUser(Guid UserId);
    
}