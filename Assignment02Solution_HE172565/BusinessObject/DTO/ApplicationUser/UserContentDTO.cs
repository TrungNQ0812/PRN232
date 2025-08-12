using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO.ApplicationUser
{
    public class UserContentDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
