using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Contact :BaseEntity
    {
        [Required, StringLength(255)]
        public string Address { get; set; }
        [Required, StringLength(255)]
        public string Phone1 { get; set; }
        [Required, StringLength(255)]
        public string Phone2 { get; set; }
        [Required, StringLength(255)]
        public string Email { get; set; }
        [Required, StringLength(255)]
        public string WebSite { get; set; }
    }
}
