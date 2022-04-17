using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Areas.AdminArea.ViewModels
{
    public class CategoryVM
    {
        public List<string> Names { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; }

    }
}
