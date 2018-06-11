using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SortApp.Models;

namespace SortApp.Controllers
{
    public class HomeController : Controller
    {
        UserContext db;
        public HomeController(UserContext context)
        {
            db = context;
        }

        public async Task<IActionResult> Index(SortState sortOrder = SortState.NameAsc)
        {
            IQueryable<User> users = db.Users.Include(x => x.Company);

            //ViewData["NameSort"] = sortOrder == SortState.NameAsc ? SortState.NameDesc : SortState.NameAsc;
            //ViewData["AgeSort"] = sortOrder == SortState.AgeAsc ? SortState.AgeDesc : SortState.AgeAsc;
            //ViewData["CompSort"] = sortOrder == SortState.CompanyAsc ? SortState.CompanyDesc : SortState.CompanyAsc;

            switch (sortOrder)
            {
                case SortState.NameDesc:
                    users = users.OrderByDescending(s => s.Name);
                    break;
                case SortState.AgeAsc:
                    users = users.OrderBy(s => s.Age);
                    break;
                case SortState.AgeDesc:
                    users = users.OrderByDescending(s => s.Age);
                    break;
                case SortState.CompanyAsc:
                    users = users.OrderBy(s => s.Company);
                    break;
                case SortState.CompanyDesc:
                    users = users.OrderByDescending(s => s.Company);
                    break;
                default:
                    users = users.OrderBy(s => s.Name);
                    break;
            }

            IndexViewModel viewModel = new IndexViewModel
            {
                Users = await users.AsNoTracking().ToListAsync(),
                SortViewModel = new SortViewModel(sortOrder)

            };

            return View(viewModel);
        }
    }
}
