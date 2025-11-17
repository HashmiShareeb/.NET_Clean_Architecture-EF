using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace crispy_winner.Domain.Entities
{
    public class Users
    {
        public string? UserId { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}