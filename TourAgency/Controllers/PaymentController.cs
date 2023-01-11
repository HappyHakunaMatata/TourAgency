﻿using System;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TourAgency.ViewModels;
using TourAgency.Data;

namespace TourAgency.Controllers
{
    public class PaymentController: Controller
    {
        

        public PaymentController()
        {
            
        }

        public IActionResult Index()
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

