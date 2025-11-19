using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace crispy_winner.Domain.Entities
{
    public class Budget
    {
        public Guid UserId { get; set; }

        public Guid CategoryId { get; set; }

        public decimal Amount { get; set; }

        public DateTime Month { get; set; }
    }
}