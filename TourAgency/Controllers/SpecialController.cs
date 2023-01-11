﻿using System;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TourAgency.ViewModels;
using TourAgency.Data;

namespace TourAgency.Controllers
{
    public class SpecialController: Controller
    {

        public SpecialController()
        {
            
        }

        public IActionResult Profitable()
        {
            return View();
        }

        public IActionResult Guest()
        {
            return View();
        }

        public IActionResult Cheap()
        {
            return View();
        }

        public IActionResult Cashback()
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
