using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Skill :BaseEntity
    {
        public bool IsDeleted { get; set; }
        [Required, StringLength(20)]
        public string Name { get; set; }
        public IList<TeacherSkill> TeacherSkills { get; set; }
    }
}
