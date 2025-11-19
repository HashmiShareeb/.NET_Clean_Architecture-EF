using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace crispy_winner.Domain.Entities
{
    
    public class Categories
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryType { get; set; }
    }
}