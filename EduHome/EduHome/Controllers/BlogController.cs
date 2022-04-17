using EduHome.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using EduHome.Models;


namespace EduHome.Controllers
{
    public class BlogController : Controller
    {
        private readonly AppDbContext _context;
        public BlogController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int? page)
        {
            ViewBag.PageCount = Math.Ceiling((decimal)_context.Blogs.Count() / 3);
            ViewBag.Page = page;
            if (page == null)
            {
                return View(_context.Blogs.OrderByDescending(p => p.Id).Take(3).ToList());
            }
            else
            {
                return View(_context.Blogs.OrderByDescending(p => p.Id).Skip(((int)page - 1) * 3).Take(3).ToList());
            }


        }

        public IActionResult Detail()
        {

            return View();
        }
    }
}
