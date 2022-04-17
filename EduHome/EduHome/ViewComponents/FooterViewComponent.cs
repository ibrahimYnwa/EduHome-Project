using EduHome.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewComponents
{
    public class FooterViewComponent :ViewComponent
    {
        private readonly AppDbContext _context;
        public FooterViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var contact = _context.Contact.ToList().ElementAt(0);

            return View(contact);
        }

    }
}
