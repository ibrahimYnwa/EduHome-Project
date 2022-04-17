using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class CourceCategory : BaseEntity 
    {
        public int CategoryId { get; set; }
        public Category Category { get; set; }
            
        public int CourseId { get; set; }
        public Cource Cource { get; set; }
    }
}
