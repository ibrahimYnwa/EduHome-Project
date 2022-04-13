using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class NoticeBoard:BaseEntity
    {
        [Required]
        public DateTime? Date { get; set; }

        [Required, StringLength(300)]
        public string Message { get; set; }
        public bool IsDeleted { get; set; }
    }
}

