using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Testimonial : BaseEntity
    {

        [Required, StringLength(255)]
        public string PersonPhoto { get; set; }
        [Required, StringLength(500)]
        public string Text { get; set; }
        [Required, StringLength(255)]
        public string Fullname { get; set; }
        [Required, StringLength(255)]
        public string Position { get; set; }
    }
}
