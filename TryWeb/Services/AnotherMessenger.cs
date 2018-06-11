using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TryWeb.Services
{
    public class AnotherMessenger : IServiceMessenger
    {
        public string Send()
        {
            return "Another ONE!";
        }
    }
}
