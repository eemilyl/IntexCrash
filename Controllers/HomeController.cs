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

// This is the controller for the pages
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

        // For the landing page
        public IActionResult Index()
        {
            List<Accident> accidents = _repo.Accidents

                .OrderBy(x => x.CRASH_ID)
                .ToList();

            return View(accidents);
        }
        // Authorize makes it so you have to login to view this page
        [Authorize]
        // this is for displaying the data
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

        // this is for the form to add/edit 
        [HttpGet]
        public IActionResult NewAccident()
        {

            ViewBag.Accidents = _repo.Accidents.ToList();

            return View();
        }


        // this is for the post when adding a record and returns the user the Confirmation page 
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
        // For the edit: goes to the add accident form with the data populated in the fields
        [Authorize]
        [HttpGet]
        public IActionResult Edit(int CRASHID)
        {

            var application = _repo.Accidents.Single(x => x.CRASH_ID == CRASHID);

            return View("NewAccident", application);
        }
        // Redirects to the Accident List
        [Authorize]
        [HttpPost]
        public IActionResult Edit(Accident mv)
        {
            _repo.Update(mv);
            _repo.SaveChanges();

            return RedirectToAction("AccidentList");
        }

        // for the delete button, asks if the user wants to actually delete the record
        [Authorize]
        [HttpGet]

        public IActionResult Delete(int applicationid)
        {

            var application = _repo.Accidents.Single(x => x.CRASH_ID == applicationid);

            return View(application);
        }
        // delete post
        [Authorize]
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
