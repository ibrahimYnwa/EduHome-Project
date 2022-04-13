using EduHome.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewComponents
{
    public class NoticeBoardViewComponent : ViewComponent
    {
        //public AppDbContext _context { get; }
        private readonly AppDbContext _context;
        public NoticeBoardViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var messages = await _context.NoticeBoard.ToListAsync();


            return (await Task.FromResult(View(messages)));
        }
    }
}
