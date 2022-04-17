using EduHome.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewModels
{
    public class ContactVM
    {
        [Required, StringLength(255)]
        public string Name { get; set; }
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, StringLength(100)]
        public string Message { get; set; }
        public string Subject { get; set; }
        [Required, StringLength(2000)]
        public Contact Contact { get; set; }
    }
}
