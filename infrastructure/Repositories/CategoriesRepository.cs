using crispy_winner.Domain.Entities;
using crispy_winner.infrastructure.context;
using FinancialApi.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace FinancialApi.infrastructure.Repositories;

public class CategoriesRepository : ICategoriesRepository
{
    private readonly ApplicationContext _context;
    public CategoriesRepository(ApplicationContext context)
    {
        _context = context;
    }


    public async  Task<IEnumerable<Categories>> GetAllCategories()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<Categories> GetCategoryById(Guid CategoryId)
    {
        return await _context.Categories.FindAsync(CategoryId);
    }

    public async Task<Categories> AddCategory(Categories categories)
    {
        await _context.AddAsync(categories);
        await _context.SaveChangesAsync();
        return categories;
    }

    public async Task UpdateCategory(Categories categories)
    {
        _context.Update(categories);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteCategory(Guid CategoryId)
    {
      _context.Remove(_context.Categories.Find(CategoryId));
      await _context.SaveChangesAsync();
    }
}