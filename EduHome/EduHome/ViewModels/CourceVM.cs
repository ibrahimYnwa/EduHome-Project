using EduHome.Models;
using X.PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.ViewModels
{
    public class CourceVM
    {
        public IPagedList<Cource> Courses { get; set; }
    }
}
