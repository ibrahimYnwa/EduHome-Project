using EduHome.Data;
using EduHome.Models;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task  <IActionResult>Index()
        {
            List<HomeSlider> homeSliders = await _context.Slider.ToListAsync();
            List<Service> services = await _context.Service.ToListAsync();
            var Events = await _context.Events.Where(e => e.IsDeleted == false)
               .Include(e => e.EventImage)
               .OrderByDescending(e => e.Id)
               .Take(4)
               .ToListAsync();


            HomeVM homeVM = new HomeVM
            {
                Sliders = homeSliders,
                Services=services,
                Events = Events

            };
            return View(homeVM);
        }
    }
}
