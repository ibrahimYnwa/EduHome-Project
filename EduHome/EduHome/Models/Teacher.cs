using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Teacher :BaseEntity
    {
        public bool IsDeleted { get; set; }
        [Required, StringLength(255)]
        public string FullName { get; set; }
        [Required, StringLength(50)]
        public string Position { get; set; }
        [Required, StringLength(1000)]
        public string Info { get; set; }
        [Required, StringLength(500)]
        public string Degree { get; set; }
        [Required, StringLength(150)]
        public string Experience { get; set; }
        [Required, StringLength(150)]
        public string Hobbies { get; set; }
        [Required, StringLength(150)]
        public string Faculty { get; set; }
        public IList<TeacherSkill> TeacherSkills { get; set; }
        public TeacherInfo TeacherInfo { get; set; }
        public TeacherImage TeacherImage { get; set; }
    }
}
