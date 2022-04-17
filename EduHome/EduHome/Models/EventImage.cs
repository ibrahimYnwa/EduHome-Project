using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class EventImage : BaseEntity 
    {
        [Required]
        public string Photo { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
