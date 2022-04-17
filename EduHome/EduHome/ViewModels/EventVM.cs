using EduHome.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList.Mvc.Core;
using X.PagedList;
using X.PagedList.Mvc;



namespace EduHome.ViewModels
{
    public class EventVM
    {
        public IPagedList<Event> Events { get; set; }
    }
}

