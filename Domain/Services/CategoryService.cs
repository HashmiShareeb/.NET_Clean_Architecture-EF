using crispy_winner.Domain.Entities;
using FinancialApi.Domain.Interfaces;

namespace FinancialApi.Applications;

public class CategoryService
{
    
    private readonly ICategoriesRepository _categoryRepository;

    public CategoryService(ICategoriesRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public Task<IEnumerable<Categories>> GetAllCat() => _categoryRepository.GetAllCategories();
    
    public Task<Categories> GetCatById(Guid id) => _categoryRepository.GetCategoryById(id);

    public async Task<Categories> CreateCat(Categories category)
    {
        category.CategoryId = Guid.NewGuid();
        return await _categoryRepository.AddCategory(category);
    }
}