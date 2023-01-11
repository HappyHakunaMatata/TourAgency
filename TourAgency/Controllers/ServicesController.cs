using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TourAgency.ViewModels;
using TourAgency.Models;
using TourAgency.Data;
using Microsoft.EntityFrameworkCore;

namespace TourAgency.Controllers
{
    public class ServicesController : Controller
    {
        public static List<Country> countries = new List<Country>();
        private readonly AppDbContext _context;
        public ServicesController(AppDbContext context)
        {
            _context = context;
            countries = _context.Countries.ToList();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Corporate()
        {
            return View();
        }

        public IActionResult Certificate()
        {
            return View();
        }

        public IActionResult Accomodation()
        {
            return View();
        }

        public IActionResult Insurance()
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