using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crispy_winner.Domain.Entities;
using FinancialApi.Applications;
using FinancialApi.Applications.DTO;
using Microsoft.AspNetCore.Mvc;

namespace crispy_winner.Presentation.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class BudgetsController : ControllerBase
    {
        private readonly BudgetService _budgetService;

        public BudgetsController(BudgetService _budgetService)
        {
            this._budgetService = _budgetService;
        }

        public static List<Budget> budgets = new List<Budget>
        {
            // sample budget
            new Budget
            {

                UserId = Guid.NewGuid(),
                Amount = 1000.00M,
                CategoryId = Guid.NewGuid(),
                Month = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1)
            }
        };
        [HttpGet]
        public ActionResult<List<Budget>> GetBudgets()
        {
            return Ok(budgets);
        }

        [HttpGet("{budgetId}")]
        public ActionResult<BudgetDTO> GetBudget(Guid budgetId)
        {
            var budget = _budgetService.GetBudgetById(budgetId);

            if (budgetId == Guid.Empty)
            {
                return BadRequest("BudgetId Not Found or doesn't exist");
            }
            
            return Ok(budget);
        }

        [HttpPost]
        public ActionResult<BudgetDTO> CreateBudget(BudgetDTO newBudgetDto)
        {
            if (newBudgetDto == null)
                return BadRequest();

            // 1. Validate user exists
            var user = UsersController.users.FirstOrDefault(u => u.UserId == newBudgetDto.UserId);
            if (user == null)
                return NotFound($"User with Id {newBudgetDto.UserId} does not exist");

            // 2. Map DTO to Budget entity
            var budget = new Budget
            {
                BudgetId = Guid.NewGuid(),
                UserId = user.UserId,
                CategoryId = newBudgetDto.CategoryId,
                Amount = newBudgetDto.AllocatedAmount,
                Month = newBudgetDto.Month
                
            };

            budgets.Add(budget);

            // 3. Map back to DTO
            var budgetDto = new BudgetDTO
            {
                BudgetId = budget.BudgetId,
                CategoryId = budget.CategoryId,
                UserId = user.UserId,
                AllocatedAmount = budget.Amount,
                Month = budget.Month,
                TotalSpent = budget.TotalSpent,
                RemainingAmount = budget.RemainingAmount,
                PercentUsed = budget.PercentUsed,
                IsExceeded = budget.IsExceeded
            };

            return CreatedAtAction(nameof(GetBudget), new { budgetId = budgetDto.BudgetId }, budgetDto);
        }

        
    }
}