using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using crispy_winner.Domain.Entities.Enums;
using Microsoft.EntityFrameworkCore;

namespace crispy_winner.Domain.Entities
{
    
    public class Categories
    {
        public Guid CategoryId { get; set; }
        public string CategoryName { get; set; }
        public CategoryType CategoryType { get; set; }
    }
}