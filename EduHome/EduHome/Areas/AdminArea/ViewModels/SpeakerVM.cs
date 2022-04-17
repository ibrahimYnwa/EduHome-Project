using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Areas.AdminArea.ViewModels
{
    public class SpeakerVM
    {
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required, StringLength(50)]
        public string Position { get; set; }
        //public IFormFile Photo { get; set; }
        public int SpeakerId { get; set; }
        public string Image { get; set; }
        public List<string> Names { get; set; }
    }
}
