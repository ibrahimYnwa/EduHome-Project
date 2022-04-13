using EduHome.Data;
using EduHome.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using EduHome.Areas.AdminArea.ViewModels;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EduHome.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class NoticeBoardController : Controller
    {
        private readonly AppDbContext _context;
        public NoticeBoardController(AppDbContext context)
        {
            _context = context;
        }
        public async Task <IActionResult> Index()
        {
            List<NoticeBoard> noticeBoards = await _context.NoticeBoard.ToListAsync();

            return View(noticeBoards);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> Create(NoticeBoardVM noticeBoardVM)
        {
            if (!ModelState.IsValid) return NotFound();
            NoticeBoard noticeBoard = new NoticeBoard
            {
                Message = noticeBoardVM.Message,
                Date = noticeBoardVM.Date,
                IsDeleted = false
            };
            await _context.NoticeBoard.AddAsync(noticeBoard);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {

            var existingNoticeBoard = await _context.NoticeBoard.Where(nb => nb.IsDeleted == false).FirstOrDefaultAsync(nb => nb.Id == id);
            if (existingNoticeBoard == null) return NotFound();
            NoticeBoardVM noticeBoardVM = new NoticeBoardVM
            {
                Message = existingNoticeBoard.Message,
                Date = existingNoticeBoard.Date,
                NoticeBoarId = existingNoticeBoard.Id
            };
            return View(noticeBoardVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(NoticeBoardVM noticeBoardVM)
        {
            var existingNoticeBoard = await _context.NoticeBoard.Where(nb => nb.IsDeleted == false).FirstOrDefaultAsync(nb => nb.Id == noticeBoardVM.NoticeBoarId);
            if (existingNoticeBoard == null) return NotFound();
            if (!ModelState.IsValid) return View(noticeBoardVM);
            existingNoticeBoard.Message = noticeBoardVM.Message;
            existingNoticeBoard.Date = noticeBoardVM.Date;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var existingNoticeBoard = await _context.NoticeBoard.Where(nb => nb.IsDeleted == false).FirstOrDefaultAsync(nb => nb.Id == id);
            if (existingNoticeBoard == null) return NotFound();
            existingNoticeBoard.IsDeleted = true;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }



    }
}
