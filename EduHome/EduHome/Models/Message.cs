using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Message :BaseEntity
    {
        [Required, StringLength(255)]
        public string Name { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, StringLength(150)]
        public string Subject { get; set; }
        [Required, StringLength(4000)]
        public string Text { get; set; }
    }

}
