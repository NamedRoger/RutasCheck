using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RutasCheck.ViewComponents
{
    public class PageHeaderViewComponent : ViewComponent
    {
        
        private PageHeaderProperties properties { get; set; }
        public IViewComponentResult Invoke(string titlePage, string subTitlePage)
        {
            properties = new PageHeaderProperties(titlePage,subTitlePage);
            return View("PageHeader", properties);
        }
    }

    public class PageHeaderProperties
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }

        public PageHeaderProperties(string title, string subTitle)
        {
            Title = title;
            SubTitle = subTitle;
        }
    }
}
