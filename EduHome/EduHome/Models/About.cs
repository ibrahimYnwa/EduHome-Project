using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class About
    {
        public int Id { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public string Tittle { get; set; }
        [Required]
        public string Text { get; set; }
        [NotMapped]
        [Required]
        public IFormFile Photo { get; set; }
    }
}
