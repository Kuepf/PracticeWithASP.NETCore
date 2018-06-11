using SortApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SortApp
{
    public static class SampleData
    {
        public static void Initialize(UserContext context)
        {

            context.Users.AddRange(
                new User
                {
                    Name = "Александр",
                    Age = 25,
                    Company = new Company() { Name = "Apple"}
                },
                new User
                {
                    Name = "Олег",
                    Age = 27,
                    Company = new Company() { Name = "Samsung" }
                },
                new User
                {
                    Name = "Андрей",
                    Age = 22,
                    Company = new Company() { Name = "Apple" }
                });
            context.SaveChanges();
        }
    }
}
