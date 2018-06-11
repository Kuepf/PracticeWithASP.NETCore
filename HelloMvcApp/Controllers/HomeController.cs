using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HelloMvcApp.Models;
using HelloMvcApp.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace HelloMvcApp.Controllers
{
    public class HomeController : Controller
    {
        MobileContext db;
        public HomeController(MobileContext context)
        {
            db = context;
        }        
        public async Task<IActionResult> Index()
        {
            return View(await db.Phones.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Phone phone)
        {
            db.Phones.Add(phone);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                Phone phone = await db.Phones.FirstOrDefaultAsync(p => p.Id == id);
                if (phone != null)
                    return View(phone);
            }
            return NotFound();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if(id != null)
            {
                Phone phone = await db.Phones.FirstOrDefaultAsync(p => p.Id == id);
                if (phone != null)
                    return View(phone);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Phone phone)
        {
            db.Phones.Update(phone);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if(id != null)
            {
                Phone phone = await db.Phones.FirstOrDefaultAsync(p => p.Id == id);
                if (phone != null)
                    return View(phone);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Phone phone = new Phone { Id = id.Value };
                db.Entry(phone).State = EntityState.Deleted;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return NotFound();  
        }

        [HttpGet]
        public IActionResult Buy(int Id)
        {
            ViewBag.PhoneId = Id;
            return View();
        }
        [HttpPost]
        public string Buy(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return "Спасибо," + order.User + ", за покупку!";
        }
        [HttpPost]
        public string Square(int altitude, int height)
        {
            double square = altitude * height / 2;
            return $"Площадь треугольника с основанием {altitude} и высотой {height} равна{square}";
        }
        public HtmlResult GetHtml()
        {
            return new HtmlResult("<h2>Привет ASP.NET Core</h2>");
        }
        public void HeadInfo()
        {
            string table = "";
            foreach(var header in Request.Headers)
            {
                table += $"<tr><td>{header.Key}</td><td>{header.Value}</td></tr>";
            }
            Response.WriteAsync(String.Format("<table>{0}</table>", table));
        }
    }
}
