﻿using EduHome.Data;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class CourceController : Controller     
    {
        private readonly AppDbContext _context;
        public CourceController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int? number)
        {
            var Courses = _context.Cources.Where(c => c.IsDeleted == false)
                .OrderByDescending(c => c.Id)
                .Include(c => c.CourseImage)
                .ToList()
                .ToPagedList(number ?? 1, 12);
            CourceVM courseVM = new CourceVM
            {
                Courses = Courses
            };

            return View(courseVM);
        }
        public IActionResult CourseDetail(int id)
        {
            var course = _context.Cources.Where(c => c.IsDeleted == false)
                .Include(c => c.CourseCategories)
                .ThenInclude(c => c.Category)
                .Include(c => c.CourseImage)
                .FirstOrDefault(c => c.Id == id);

            List<string> Categories = new List<string>();

            foreach (var courseCategory in course.CourseCategories)
            {
                Categories.Add(courseCategory.Category.Name);
            }

            CourceDetailVM courseDetailVM = new CourceDetailVM()
            {
                Categories = Categories,
                Name = course.Name,
                Language = course.Language,
                ApplicationRule = course.ApplicationRule,
                Fee = course.Fee,
                Assesment = course.Assesment,
                Certification = course.Certification,
                ClassDuration = course.ClassDuration,
                StudentCapacity = course.StudentCapacity,
                Description = course.Description,
                Duration = course.Duration,
                StartDate = course.StartDate,
                SkillLevel = course.SkillLevel,
                Title = course.Title
            };
            return View(courseDetailVM);
        }
    }
}
