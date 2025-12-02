using crispy_winner.Domain.Entities;
using FinancialApi.Applications;
using Microsoft.AspNetCore.Mvc;

namespace crispy_winner.Presentation.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/[controller]")]
[ApiVersion("1.0")]
public class CategoriesController : ControllerBase
{
    private readonly CategoryService _categoryService;

    public CategoriesController(CategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Categories>>> GetCategories()
        => Ok(await _categoryService.GetAllCat());

    [HttpGet("{categoryId}")]
    public async Task<ActionResult<Categories>> GetCategory(Guid categoryId)
    {
        var category = await _categoryService.GetCatById(categoryId);
        if (category == null)
        {
            return NotFound();
        }

        return Ok(category);
    }
    
    [HttpPost]
    public async Task<ActionResult<Categories>> CreateCategory([FromBody] Categories category)
    {
        if (category == null)
            return BadRequest("Category is required.");

        var created = await _categoryService.CreateCat(category);

        return CreatedAtAction(nameof(GetCategory), 
            new { categoryId = created.CategoryId }, created);
    }





}
