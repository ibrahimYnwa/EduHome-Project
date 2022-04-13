using EduHome.Models;
using Microsoft.AspNetCore.Http;
using System;


namespace EduHome.Areas.AdminArea.ViewModels
{
    public class SliderVM
    {
        public IFormFile Photo { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int SliderId { get; set; }
        public HomeSlider HomeSlider { get; set; }
    }
}
