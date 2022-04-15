using EduHome.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewComponents
{
    public class TeacherViewComponent :ViewComponent
    {
        private readonly AppDbContext _context;
        public TeacherViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int count)
        {
            var Teachers = await _context.Teachers.Where(t => t.IsDeleted == false)
                .Take(count)
                .OrderByDescending(t => t.Id)
                .Include(t => t.TeacherImage)
                .Include(t => t.TeacherInfo)
                .ToListAsync();

            return View(Teachers);
        }

    }
}
