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

            HomeVM homeVM = new HomeVM
            {
                Sliders = homeSliders,
                Services=services

            };
            return View(homeVM);
        }
    }
}
