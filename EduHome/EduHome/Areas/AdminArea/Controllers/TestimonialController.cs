using EduHome.Areas.AdminArea.Helpers;
using EduHome.Areas.AdminArea.ViewModels;
using EduHome.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class TestimonialController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public TestimonialController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            var testimonial = _context.Testimonial.ToList().ElementAt(0);
            return View(testimonial);
        }

        //public IActionResult Edit()
        //{
        //    var testimonial = _context.Testimonial.ToList().ElementAt(0);
        //    TestimonialVM testimonalVM = new TestimonialVM
        //    {
        //        Fullname = testimonial.Fullname,
        //        Position = testimonial.Position,
        //        Text = testimonial.Text,
        //        Image = testimonial.PersonPhoto
        //    };
        //    return View(testimonalVM);
        //}

        //private async Task<TestimonialVM> GetTestimonialById(int id)
        //{
        //    return await _context.Testimonial.FindAsync();
        //}

        // public async Task<IActionResult> Edit(int id,TestimonialVM testimonalVM)
        // {


        //        var dbTestimonial = await GetTestimonialById(id);

        //        if (dbTestimonial == null) return NotFound();

        //         if (ModelState["Photo"].ValidationState == ModelValidationState.Invalid) return View(dbTestimonial);
        //         if (!testimonalVM.Photo.CheckFileType("image/"))
        //         {
        //             ModelState.AddModelError("Photo", "Image type is wrong");
        //             return View(dbTestimonial);

        //         }

        //         if (!testimonalVM.Photo.CheckFileSize(200))
        //         {
        //             ModelState.AddModelError("Photo", "Image size is wrong");
        //             return View(dbTestimonial);
        //         }

        //         string path = FileHelper.GetFilePath(_env.WebRootPath, "img/slider", dbTestimonial.Image);

        //         FileHelper.DeleteFile(path);

        //         string fileName = Guid.NewGuid().ToString() + "_" + testimonalVM.Photo.FileName;

        //         string newPath = FileHelper.GetFilePath(_env.WebRootPath, "img/testimonial", fileName);

        //         using (FileStream stream = new FileStream(newPath, FileMode.Create))
        //         {
        //         await testimonalVM.Photo.CopyToAsync(stream);
        //         }

        //         dbTestimonial.Image = fileName;
        //         await _context.SaveChangesAsync();

        //         //return View(slider);
        //         return RedirectToAction(nameof(Index));
        //         }

        //}

    }
}


