using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace HelloMvcApp.Areas.Store.Controllers
{
    [Area("Store")]
    public class SomeController : Controller
    {
        public IActionResult Ind()
        {
            return View();
        }
    }
}
