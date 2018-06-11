using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TryWeb.Services
{
    public class ServiceMessenger : IServiceMessenger
    {
        public string Send()
        {
            return "Hello from Kuepf!";
        }
    }
}
