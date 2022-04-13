using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Areas.AdminArea.ViewModels
{
    public class NoticeBoardVM
    {
        [Required, StringLength(300)]
        public string Message { get; set; }
        [Required]
        public DateTime? Date { get; set; }
        public int NoticeBoarId { get; set; }
    }
}
