using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Event :BaseEntity
    {
        [Required, StringLength(50)]
        public string Name { get; set; }
        [Required]
        public DateTime? StartTime { get; set; }
        [Required]
        public DateTime? EndTime { get; set; }
        [Required, StringLength(50)]
        public string Venue { get; set; }
        [Required, StringLength(500)]
        public string Description { get; set; }
        public IList<SpeakerEvent> SpeakerEvents { get; set; }
        public IList<EventCategory> EventCategories { get; set; }
        public EventImage EventImage { get; set; }
        public bool IsDeleted { get; set; }
    }
}
