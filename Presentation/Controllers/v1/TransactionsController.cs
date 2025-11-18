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

    public class TransactionsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("This is the TransactionsController for API version 1.0");
        }

        [HttpPost]
        public ActionResult CreateTransaction(Transaction transaction)
        {
            if (transaction == null)
            {
                return BadRequest(); // return bad request if transaction is null
            }


            return CreatedAtAction(nameof(Get), new { }, transaction); // return 201 status code
        }



    }
}