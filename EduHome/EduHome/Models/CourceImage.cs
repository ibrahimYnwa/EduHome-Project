using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class CourceImage : BaseEntity 
    {
        [Required, StringLength(255)]
        public string Photo { get; set; }
        public int CourseId { get; set; }
        public Cource Course { get; set; }
    }

}
