using EduHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewModels
{
    public class HomeVM
    {
        public List<HomeSlider> Sliders { get; set; }
        public List<Service> Services { get; set; }
        //public List<Course> Courses { get; set; }
        public List<Event> Events { get; set; }
    }
}
