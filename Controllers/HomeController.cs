using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using intex2.Models;
using intex2.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace intex2.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;

        private AccidentsDbContext _repo { get; set; }

        public PageInfo PageInfo { get; private set; }

        public HomeController(AccidentsDbContext temp)
        {
            _repo = temp;
        }

        public IActionResult Index()
        {
            List<Accident> accidents = _repo.Accidents

                .OrderBy(x => x.CRASH_ID)
                .ToList();

            return View(accidents);
        }

        [Authorize]
        public IActionResult AccidentList(string county, int pageNum = 1)
        {
            int pageSize = 10000;

            var x = new AccidentsViewModel
            {
                 //pagination set up

                Accidents = _repo.Accidents
                .Where(c => c.COUNTY_NAME == county || county == null)
                .OrderBy(x => x.CRASH_ID)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize)
                .ToList(),

                PageInfo = new PageInfo
                {
                    TotalNumAccidents = _repo.Accidents.Count(),
                    AccidentsPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
        }

        public IActionResult AccidentListUsers(string county, int pageNum = 1)
        {
            int pageSize = 10000;

            var x = new AccidentsViewModel
            {
                //pagination set up

                Accidents = _repo.Accidents
                .Where(c => c.COUNTY_NAME == county || county == null)
                .OrderBy(x => x.CRASH_ID)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize)
                .ToList(),
                

                PageInfo = new PageInfo
                {
                    TotalNumAccidents = _repo.Accidents.Count(),
                    AccidentsPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
        }


        [HttpGet]
        public IActionResult NewAccident()
        {

            ViewBag.Accidents = _repo.Accidents.ToList();

            return View();
        }



        [HttpPost]
        public IActionResult NewAccident(Accident ar)
        {
            //if (ModelState.IsValid)
            //{
                _repo.Add(ar);
                _repo.SaveChanges();

                return View("Confirmation", ar);
            //}

            ////else //if invalid
            ////{
            //    ViewBag.Accidents = _repo.Accidents.ToList();
            //    return View(ar);
            //}
        }

            [HttpGet]
        public IActionResult Edit(int CRASHID)
        {

            var application = _repo.Accidents.Single(x => x.CRASH_ID == CRASHID);

            return View("NewAccident", application);
        }

        [HttpPost]
        public IActionResult Edit(Accident mv)
        {
            _repo.Update(mv);
            _repo.SaveChanges();

            return RedirectToAction("AccidentList");
        }


        [HttpGet]
        public IActionResult Delete(int applicationid)
        {

            var application = _repo.Accidents.Single(x => x.CRASH_ID == applicationid);

            return View(application);
        }
        [HttpPost]
        public IActionResult Delete(Accident mv)
        {
            _repo.Accidents.Remove(mv);
            _repo.SaveChanges();

            return RedirectToAction("AccidentList");
        }

        public IActionResult Privacy()
        {

            return View();
        }

    }
}
