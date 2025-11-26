using crispy_winner.Domain.Entities;

namespace FinancialApi.Domain.Interfaces;

public interface ICategoriesRepository
{
    Task<IEnumerable<Categories>> GetAllCategories();
    Task<Categories> GetCategoryById(Guid categoryId);
    Task<Categories> AddCategory(Categories categories);
    Task UpdateCategory(Categories categories);
    Task DeleteCategory(Guid categoryId);
    
    
}