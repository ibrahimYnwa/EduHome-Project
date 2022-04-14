using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Areas.AdminArea.ViewModels
{
    public class TestimonialVM
    {
        [Required, StringLength(500)]
        public string Text { get; set; }
        [Required, StringLength(255)]
        public string Fullname { get; set; }
        [Required, StringLength(255)]
        public string Position { get; set; }
        public string Image { get; set; }
        public IFormFile Photo { get; set; }
    }
}
