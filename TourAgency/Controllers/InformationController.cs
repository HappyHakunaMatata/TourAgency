using System;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TourAgency.ViewModels;
using TourAgency.Data;

namespace TourAgency.Controllers
{
    public class InformationController:Controller
    {

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Documents()
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

