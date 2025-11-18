using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crispy_winner.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace crispy_winner.Presentation.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class BudgetsController : ControllerBase
    {

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
    }
}