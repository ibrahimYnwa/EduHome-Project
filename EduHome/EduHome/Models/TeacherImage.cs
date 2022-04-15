using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class TeacherImage :BaseEntity 
    {
        [Required, StringLength(255)]
        public string Photo { get; set; }
        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}
