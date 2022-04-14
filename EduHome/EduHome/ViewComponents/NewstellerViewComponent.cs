using EduHome.Data;
using EduHome.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewComponents
{
    public class NewstellerViewComponent :ViewComponent
    {
        private readonly AppDbContext _context;
        public NewstellerViewComponent(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync(Subscriber subscireber)
        {
            return View(subscireber);
        }
    }
}
