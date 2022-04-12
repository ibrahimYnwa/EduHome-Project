using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class HomeSlider
    {
        public int Id { get; set; }
        [Required]
        public string Image { get; set; }
        public string Tittle { get; set; }
        public string Text { get; set; }
    }
}
