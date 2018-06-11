using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkDataBase.Models;

namespace WorkDataBase.Controllers
{
    public class HomeController : Controller
    {
        UserContext db;
        public HomeController(UserContext context)
        {
            db = context;
        }
        public async Task<IActionResult> Index()
        {
            IQueryable<User> users = db.Users.Include(x => x.Car);

            IndexViewModel viewModel = new IndexViewModel
            {
                Users = await users.AsNoTracking().ToListAsync()
            };

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> GetCar(Guid id)
        {
            IQueryable<User> users = db.Users.Include(x => x.Car);
            ViewBag.CarId = id;

            IndexViewModel viewModel = new IndexViewModel
            {
                Users = await users.AsNoTracking().ToListAsync()
            };
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            db.Users.Add(user);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id != null)
            {
                User users = await db.Users
                    .Include(c => c.Car)
                    .FirstOrDefaultAsync(p => p.Id == id);

                if (users != null)
                    return View(users);
            }

            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid? id,Guid? carId)
        {
            if (id != null)
            {
                User user = await db.Users
                    .Include(c => c.Car)
                    .FirstOrDefaultAsync(x => x.Id == id);
                if (user != null)
                    return View(user);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(User user,Guid? carId)
        {
            Car car = await db.Cars.FirstOrDefaultAsync(p => p.Id == carId);
            db.Users.Update(user);
            await db.SaveChangesAsync();
            db.Cars.Remove(car);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(Guid? id, Guid? carId)
        {
            if (id != null)
            {
                User user = await db.Users
                    .FirstOrDefaultAsync(x => x.Id == id);
                Car car = await db.Cars.FirstOrDefaultAsync(p => p.Id == carId);
                if (user != null)
                    return View(user);
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid? id, Guid? carId)
        {

            if (id != null)
            {
                ViewBag.CarID = carId;
                User user = await db.Users
                    .Include(x => x.Car)
                    .FirstOrDefaultAsync(p => p.Id == id);
                if (user != null)
                {
                    db.Cars.Remove(user.Car);
                    db.Users.Remove(user);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }

            return NotFound();
        }

    }
}
