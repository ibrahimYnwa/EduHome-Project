using EduHome.Areas.AdminArea.Helpers;
using EduHome.Areas.AdminArea.ViewModels;
using EduHome.Data;
using EduHome.Models;
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
    public class SliderController : Controller
    {

        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public SliderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;

        }
        public async Task<IActionResult> Index()
        {
            List<HomeSlider> homeSliders = await _context.Slider.ToListAsync();
            return View(homeSliders);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HomeSlider sliderVM)
        {
            if (ModelState["Photo"].ValidationState == ModelValidationState.Invalid) return View();
            //if (ModelState["Tittle"].ValidationState == ModelValidationState.Invalid) return View();
            //if (ModelState["Text"].ValidationState == ModelValidationState.Invalid) return View();

            if (!sliderVM.Photo.CheckFileType("image/")) 
                {
                    ModelState.AddModelError("Photos", "Image type is wrong");
                    return View();
                }
                if (!sliderVM.Photo.CheckFileSize(8000))
                {
                    ModelState.AddModelError("Photos", "Image size is wrong");
                    return View();
                }


            string fileName = Guid.NewGuid().ToString() + "_" + sliderVM.Photo.FileName;
            string path = FileHelper.GetFilePath(_env.WebRootPath, "img/slider", fileName);

            await sliderVM.Photo.SaveFile(path);

            sliderVM.Image = fileName;
            

           
            await _context.Slider.AddAsync(sliderVM);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task < IActionResult> Delete(int id)
        {
            var slider = await _context.Slider.FirstOrDefaultAsync(m => m.Id == id);
            if (slider == null) return NotFound();
            string path = FileHelper.GetFilePath(_env.WebRootPath, "img/slider", slider.Image);
            FileHelper.DeleteFile(path);
            _context.Slider.Remove(slider);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> Edit(int id)
        {
            var slider = await GetSliderById(id);
            if (slider is null) return NotFound();
            return View(slider);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, HomeSlider slider)
        {
            var dbSlider = await GetSliderById(id);

            if (dbSlider == null) return NotFound();

            if (ModelState["Photo"].ValidationState == ModelValidationState.Invalid) return View(dbSlider);
            if (!slider.Photo.CheckFileType("image/"))
            {
                ModelState.AddModelError("Photo", "Image type is wrong");
                return View(dbSlider);

            }

            if (!slider.Photo.CheckFileSize(200))
            {
                ModelState.AddModelError("Photo", "Image size is wrong");
                return View(dbSlider);
            }

            string path = FileHelper.GetFilePath(_env.WebRootPath, "img/slider", dbSlider.Image);

            FileHelper.DeleteFile(path);

            string fileName = Guid.NewGuid().ToString() + "_" + slider.Photo.FileName;

            string newPath = FileHelper.GetFilePath(_env.WebRootPath, "img/slider", fileName);

            using (FileStream stream = new FileStream(newPath, FileMode.Create))
            {
                await slider.Photo.CopyToAsync(stream);
            }

            dbSlider.Image = fileName;   
            await _context.SaveChangesAsync();

            //return View(slider);
            return RedirectToAction(nameof(Index));
        }

        private async Task<HomeSlider> GetSliderById(int id)
        {
            return await _context.Slider.FirstAsync();
        }

    }
} 

       
        
    


