using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WorkDataBase.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public Car Car { get; set; }
    }

    public class Car
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
