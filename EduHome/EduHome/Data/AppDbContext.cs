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

     }

     
}
