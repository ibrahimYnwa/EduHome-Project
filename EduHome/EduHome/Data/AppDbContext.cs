using EduHome.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<HomeSlider> Slider { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<NoticeBoard> NoticeBoard { get; set; }
        public DbSet<Testimonial> Testimonial { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<TeacherImage> TeacherImage { get; set; }
        public DbSet<TeacherInfo> TeacherInfo { get; set; }
        public DbSet<TeacherSkill> TeacherSkills { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Cource> Cources { get; set; }
        public DbSet<CourceImage> CourseImage { get; set; }
        public DbSet<CourceCategory> CourseCategories { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Event> Events { get; set; }
        //burdan addi
        public DbSet <Speaker> Speakers { get; set; }
        public DbSet<SpeakerImage> SpeakerImage { get; set; }
        public DbSet<EventCategory> EventCategories { get; set; }
        public DbSet<SpeakerEvent> SpeakerEvents { get; set; }
        public DbSet<EventImage> EventImage { get; set; }



    }

     
}
