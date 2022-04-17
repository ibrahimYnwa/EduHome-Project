using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Category :BaseEntity
    {
        [Required]
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public IList<CourceCategory> CourseCategories { get; set; }
        public IList<EventCategory> EventCategories { get; set; }

    }
}
