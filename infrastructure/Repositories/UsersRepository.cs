using crispy_winner.Domain.Entities;
using crispy_winner.infrastructure.context;
using FinancialApi.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinancialApi.infrastructure.Repositories;

public class UsersRepository : IUserRepository
{
    private readonly ApplicationContext _context;
    
    public UsersRepository(ApplicationContext context)
    {
        _context = context;
    }


    public async Task<IEnumerable<Users>> GetAllUsers()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<Users> GetUserById(Guid userId)
    {
        return await _context.Users.FindAsync(userId);
    }

    public async Task<Users> AddUser(Users user)
    {
        await _context.Users.AddAsync(user);
        await _context.SaveChangesAsync();
        return user;
    }



    public async Task UpdateUser(Users user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteUser(Guid userId)
    {
       var user = await _context.Users.FindAsync(userId);
       if (user != null)
       {
           _context.Users.Remove(user);
           await _context.SaveChangesAsync();
       }
    }
}