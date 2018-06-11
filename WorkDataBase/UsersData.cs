using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkDataBase.Models;

namespace WorkDataBase
{
    public static class UsersData
    {
        public static void Initialize(UserContext context)
        {
            if (!context.Users.Any())
            {
                context.Users.AddRange(
                    new User
                    {
                        Name = "John",
                        Age = 20,
                        Car = new Car() { Name = "BMW"}
                    },
                    new User
                    {
                        Name = "Tom",
                        Age = 25,
                        Car = new Car() { Name = "Audi" }
                    },
                    new User
                    {
                        Name = "Rick",
                        Age = 19,
                        Car = new Car() { Name = "Honda" }
                    });
            }
            context.SaveChanges();
        }
    }
}
