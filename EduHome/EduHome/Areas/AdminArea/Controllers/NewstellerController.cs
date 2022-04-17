using EduHome.Data;
using EduHome.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class NewstellerController : Controller
    {
      
        private readonly AppDbContext _context;
        public NewstellerController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Subscribe(Subscriber subscriber)
        {
            if (!ModelState.IsValid) return View(subscriber);
            _context.Subscribers.Add(subscriber);
            _context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
    }
}
