using EduHome.Areas.AdminArea.Helpers;
using EduHome.Areas.AdminArea.ViewModels;
using EduHome.Data;
using EduHome.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Areas.AdminArea.Controllers
{
    [Area("AdminArea")]
    public class TeacherController : Controller
        
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public TeacherController(AppDbContext context , IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task <IActionResult> Index()
        {
            List<Teacher> Teachers = await _context.Teachers.Where(m => m.IsDeleted == false)
                 .Include(m => m.TeacherImage)
                 .Include(m => m.TeacherInfo)
                 .Include(m => m.TeacherSkills)
                 .ThenInclude(m => m.Skill)
                 .ToListAsync();

                return View(Teachers);
        }

        public async Task <IActionResult> Create()
        {
            TeacherVM teacherVM = new TeacherVM();
            teacherVM.Skills = new List<SkillVM>();
            List<Skill> Skills = await _context.Skills.Where(m => m.IsDeleted == false).ToListAsync();
            foreach (var item in Skills)
            {
                teacherVM.Skills.Add(new SkillVM { Name = item.Name });

            }
            return View(teacherVM);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TeacherVM teacherVM)
        {
            TeacherVM teacherVM1 = new TeacherVM();
            teacherVM1.Skills = new List<SkillVM>();
            List<Skill> Skills = await _context.Skills.Where(m => m.IsDeleted == false).ToListAsync();
            foreach (var skill in Skills)
            {
                teacherVM1.Skills.Add(new SkillVM { Name = skill.Name });
            }

            if (!ModelState.IsValid) return View(teacherVM1);

            var photo = teacherVM.Photo;
            if (photo==null)
            {
                ModelState.AddModelError("Photo", "Plese add photo");
                return View(teacherVM);
            }

            if (!teacherVM.Photo.CheckFileType("image/"))
            {
                ModelState.AddModelError("Photos", "Image type is wrong");
                return View(teacherVM);
            }

            if (!teacherVM.Photo.CheckFileSize(800))
            {
                ModelState.AddModelError("Photos", "Image size is wrong");
                return View(teacherVM);
            }
            string fileName = Guid.NewGuid().ToString() + "_" + teacherVM.Photo.FileName;
            string path = FileHelper.GetFilePath(_env.WebRootPath, "img/teacher", fileName);

            await teacherVM.Photo.SaveFile(path);

            Teacher teacher = new Teacher
            {
                FullName = teacherVM.Fullname,
                Position = teacherVM.Position,
                Info = teacherVM.Info,
                Degree = teacherVM.Degree,
                Experience = teacherVM.Experience,
                Hobbies = teacherVM.Hobbies,
                Faculty = teacherVM.Faculty,
                IsDeleted = false,
                TeacherImage = new TeacherImage(),
                TeacherInfo = new TeacherInfo
                {
                    Mail = teacherVM.Mail,
                    Phone = teacherVM.Phone,
                    FacebookUserName = teacherVM.FacebookUserName,
                    PinterestUserName = teacherVM.PinterestUserName,
                    TwitterUserName = teacherVM.TwitterUserName,
                    SkypeUserName = teacherVM.SkypeUserName
                }

            };

            _context.Teachers.Add(teacher);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditTeacher(TeacherVM teacherVM)
        {
            var teacher = await _context.Teachers.Where(t => t.IsDeleted == false)
                .Include(t => t.TeacherImage)
                .Include(t => t.TeacherInfo)
                .Include(t => t.TeacherSkills)
                .ThenInclude(t => t.Skill)
                .FirstOrDefaultAsync(t => t.Id == teacherVM.TeacherId);

            TeacherVM tvm = new TeacherVM();
            tvm.Skills = new List<SkillVM>();
            tvm.Teacher = teacher;
            tvm.TeacherId = teacher.Id;
            List<string> Percentages = new List<string>();
            List<Skill> Skills = await _context.Skills.Where(s => s.IsDeleted == false).ToListAsync();
            foreach (var skill in Skills)
            {
                tvm.Skills.Add(new SkillVM { Name = skill.Name });
            }
           
            List<SkillVM> existingSkills = new List<SkillVM>();
            foreach (var skill in teacher.TeacherSkills)
            {
                SkillVM skillVM = new SkillVM { Name = skill.Skill.Name };
                existingSkills.Add(skillVM);
            }

            var filteredListSkills = new List<SkillVM>();
            foreach (var item in tvm.Skills.ToList())
            {
                if (existingSkills.FirstOrDefault(c => c.Name == item.Name) != null)
                {
                    tvm.Skills.Remove(item);
                }
            }
            filteredListSkills = tvm.Skills;

            ViewBag.Skills = filteredListSkills;

            if (teacher == null) return NotFound();

            if (!ModelState.IsValid) return View(tvm);



            var existingImage = await _context.TeacherImage.FirstOrDefaultAsync(ci => ci.TeacherId == teacher.Id);
            if (existingImage == null) return NotFound();

            var photo = teacherVM.Photo;

            if (photo != null)
            {
                if (!teacherVM.Photo.CheckFileType("image/"))
                {
                    ModelState.AddModelError("Photos", "Image type is wrong");
                    return View(tvm);
                }
                if (!teacherVM.Photo.CheckFileSize(800))
                {
                    ModelState.AddModelError("Photos", "Image size is wrong");
                    return View(tvm);
                }
   

            }

            var existingTeacherSkils = await _context.TeacherSkills.Select(x => x).Where(c => c.TeacherId == teacher.Id).ToListAsync();
            foreach (var teacherSkill in existingTeacherSkils)
            {
                _context.TeacherSkills.Remove(teacherSkill);
            }

   

            teacher.FullName = teacherVM.Fullname;
            teacher.Faculty = teacherVM.Faculty;
            teacher.Degree = teacherVM.Degree;
            teacher.Experience = teacherVM.Experience;
            teacher.Info = teacherVM.Info;
            teacher.Position = teacherVM.Position;
            teacher.TeacherInfo.Mail = teacherVM.Mail;
            teacher.TeacherInfo.SkypeUserName = teacherVM.SkypeUserName;
            teacher.TeacherInfo.TwitterUserName = teacherVM.TwitterUserName;
            teacher.TeacherInfo.Phone = teacherVM.Phone;
            teacher.Hobbies = teacherVM.Hobbies;
            teacher.TeacherInfo.FacebookUserName = teacherVM.FacebookUserName;
            teacher.TeacherInfo.PinterestUserName = teacherVM.PinterestUserName;

            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteTeacher(int id)
        {
            var teacher = await _context.Teachers.Where(t => t.IsDeleted == false).FirstOrDefaultAsync(t => t.Id == id);
            if (teacher == null) return NotFound();
            teacher.IsDeleted = true;
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
