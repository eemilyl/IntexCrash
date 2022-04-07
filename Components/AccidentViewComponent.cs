using System.Linq;
using Microsoft.AspNetCore.Mvc;
using intex2.Models;

namespace intex2.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IAccidentsRepository repo { get; set; }

        public NavigationMenuViewComponent(IAccidentsRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.COUNTY_NAME = RouteData?.Values["COUNTY_NAME"];

            var var = repo.Accidents.Select(x => x.COUNTY_NAME).Distinct().OrderBy(x => x);

            return View(var);
        }
    }
}

