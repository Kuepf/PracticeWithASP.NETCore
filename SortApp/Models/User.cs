using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SortApp.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<User> Users { get; set; }
        public Company()
        {
            Users = new List<User>();
        }
    }
}
