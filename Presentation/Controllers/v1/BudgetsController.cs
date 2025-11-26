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
        public async Task<ActionResult<BudgetDTO>> CreateBudget(CreateBudgetDTO dto)
        {
            try
            {
                var createdBudget = await _budgetService.AddBudget(dto);

                var resultDto = new BudgetDTO
                {
                    BudgetId = createdBudget.BudgetId,
                    UserId = createdBudget.UserId,
                    CategoryId = createdBudget.CategoryId,
                    AllocatedAmount = createdBudget.Amount,
                    Month = createdBudget.Month,
                    TotalSpent = createdBudget.TotalSpent,
                    RemainingAmount = createdBudget.RemainingAmount,
                    PercentUsed = createdBudget.PercentUsed,
                    IsExceeded = createdBudget.IsExceeded
                };

                return CreatedAtAction(nameof(GetBudget),
                    new { budgetId = createdBudget.BudgetId },
                    resultDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}