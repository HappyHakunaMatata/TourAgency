using System;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TourAgency.ViewModels;
using TourAgency.Data;

namespace TourAgency.Controllers
{
    public class CountryController: Controller
    {

        public CountryController()
        {

        }
        public IActionResult Index()
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

