using EduHome.Data;
using EduHome.Models;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;
        public ContactController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var contact =  _context.Contact.ToList().ElementAt(0);
            ContactVM contactVM = new ContactVM
            {
                Contact = contact
            };

            return View(contactVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Index(ContactVM contactVM)
        {
            if (!ModelState.IsValid) return View(contactVM);
            Message message = new Message
            {
                Name = contactVM.Name,
                Email = contactVM.Email,
                Text = contactVM.Message,
                Subject = contactVM.Subject
            };

             await _context.Messages.AddAsync(message);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
