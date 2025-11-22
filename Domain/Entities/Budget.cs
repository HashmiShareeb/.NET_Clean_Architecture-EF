using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crispy_winner.Domain.Entities
{
    public class Budget
    {
        public Guid BudgetId { get; set; }
        public Guid UserId { get; set; }

        public Guid CategoryId { get; set; }

        public decimal Amount { get; set; }

        public DateTime Month { get; set; }
        
        public ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
        
        //Business Logic
        //don’t need to calculate anything in the service — the entity already knows.
        public decimal TotalSpent => Transactions.Sum(t => t.Amount);

        public decimal RemainingAmount => Amount - TotalSpent;

        public bool IsExceeded => TotalSpent > Amount;

        public decimal PercentUsed => Amount == 0 ? 0 : TotalSpent / Amount;

        public bool CanAddTransaction(decimal amount)
        {
            return TotalSpent + amount <= Amount;
        }

    }
}