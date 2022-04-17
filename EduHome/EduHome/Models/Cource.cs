using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Cource :BaseEntity
    {
        [Required, StringLength(255)]
        public string Name { get; set; }
        [Required, StringLength(255)]
        public string Title { get; set; }
        [Required, StringLength(500)]
        public string Description { get; set; }
        [Required, StringLength(255)]
        public string ApplicationRule { get; set; }
        [Required, StringLength(255)]
        public string Certification { get; set; }
        [Required]
        public DateTime? StartDate { get; set; }
        [Required, StringLength(50)]
        public string Duration { get; set; }
        [Required, StringLength(50)]
        public string ClassDuration { get; set; }
        [Required, StringLength(50)]
        public string SkillLevel { get; set; }
        [Required, StringLength(50)]
        public string Language { get; set; }
        [Required]
        public int? StudentCapacity { get; set; }
        [Required, StringLength(50)]
        public string Assesment { get; set; }
        [Required]
        public float? Fee { get; set; }
        [Required]
        public CourceImage CourseImage { get; set; }
        public bool IsDeleted { get; set; }
        public IList<CourceCategory> CourseCategories { get; set; }
    }
}
