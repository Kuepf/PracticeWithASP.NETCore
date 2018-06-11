using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FiltersApp.Models;
using FiltersApp.Filters;

namespace FiltersApp.Controllers
{
    public class HomeController : Controller
    {
        [SimpleResourceFilter(30,"Hello from kek")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
