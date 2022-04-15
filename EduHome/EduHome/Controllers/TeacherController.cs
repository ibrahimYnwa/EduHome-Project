using EduHome.Data;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class TeacherController : Controller
    {
        private readonly AppDbContext _context;
        public TeacherController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> TeacherDetail(int id)
        
        {
            var teacher = await _context.Teachers.AsQueryable().Where(t => t.IsDeleted == false)
                .Include(t => t.TeacherImage)
                .Include(t => t.TeacherInfo)
                .Include(t => t.TeacherSkills)
                .ThenInclude(t => t.Skill)
                .FirstOrDefaultAsync(t => t.Id == id);

            List<string> Skills = new List<string>();
            List<string> Percents = new List<string>();


            foreach (var teacherSkill in teacher.TeacherSkills)
            {
                Skills.Add(teacherSkill.Skill.Name);
                Percents.Add(teacherSkill.Percentage);
            }

            TeacherDetailVM teacherDetailVM = new TeacherDetailVM
            {
                FullName = teacher.FullName,
                Position = teacher.Position,
                Info = teacher.Info,
                Degree = teacher.Degree,
                Experience = teacher.Experience,
                Hobbies = teacher.Hobbies,
                Faculty = teacher.Faculty,
                Photo = teacher.TeacherImage.Photo,
                Mail = teacher.TeacherInfo.Mail,
                Phone = teacher.TeacherInfo.Phone,
                SkypeUserName = teacher.TeacherInfo.SkypeUserName,
                FacebookUserName = teacher.TeacherInfo.FacebookUserName,
                PinterestUserName = teacher.TeacherInfo.PinterestUserName,
                TwitterUserName = teacher.TeacherInfo.TwitterUserName,
                Skills = Skills,
                Percents = Percents
            };

            return View(teacherDetailVM);
        }
    }
}
