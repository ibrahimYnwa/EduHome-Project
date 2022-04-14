using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Models
{
    public class Subscriber :BaseEntity
    {
        [Required, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
