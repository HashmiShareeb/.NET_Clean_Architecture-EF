using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crispy_winner.Domain.Entities;
using FinancialApi.Applications;
using Microsoft.AspNetCore.Mvc;

namespace crispy_winner.Presentation.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]

    public class TransactionsController : ControllerBase
    {
        private readonly TransactionsService _transactionService;

        public TransactionsController(TransactionsService service)
        { 
            _transactionService = service;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var t = await _transactionService.GetAllTransactions();
            return Ok(t);
        }
        [HttpGet("{userId}")]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetUserTransactions(Guid userId)
            => Ok(await _transactionService.GetUserTransactions(userId));
        
        [HttpPost]
        public async Task<ActionResult<Transaction>> CreateTransaction([FromBody] Transaction transaction)
        {
            try
            {
                var created = await _transactionService.AddTransaction(transaction);
                return CreatedAtAction(nameof(GetUserTransactions), 
                    new { userId = created.UserId }, created);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}