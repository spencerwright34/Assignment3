using Assignment3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //This constructor was here when the app was created - I am replacing it with the constructor on line 25
        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
        
        private MovieListContext context { get; set; }

        //Constructor 
        public HomeController(MovieListContext con)
        {
            context = con;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EnterMovies()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnterMovies(MovieResponse appResponse)
        {
            //This if statement relates to the models
            //If the data validation in the models is respected, the user will be sent to the confirmation page
            if (ModelState.IsValid)
            {
                context.Movies.Add(appResponse);
                context.SaveChanges();
                return View("Confirmation", appResponse);
            }

            //If the data validation isn't respected, the user will be sent back to the same page in order to enter the appropriate data
            return View();
        }

        public IActionResult MovieList()
        {
            //The .where is to tell the app not to list any movies with the title 'Independence Day'
            //The movies will still be stored in the memory but will not be shown in the list
            //return View(TempStorage.Movies.Where(r => r.Title != "Independence Day"));
            return View(context.Movies.Where(r => r.Title != "Independence Day"));
        }

        public IActionResult Podcast()
        {
            return View();
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
