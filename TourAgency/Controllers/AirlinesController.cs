using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TourAgency.ViewModels;
using TourAgency.Data.Interfaces;
using TourAgency.Data.SaveTo;
using Microsoft.EntityFrameworkCore;
using TourAgency.Data;
using TourAgency.Models;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;

namespace TourAgency.Controllers
{
    public class AirlinesController: Controller
    {
        private readonly AppDbContext _context;

        public AirlinesController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Companies()
        {
            var aircompanies = await _context.aircompanies.Select(m => new Aircompany{ name = m.name, logo = m.logo, link = m.link}).Distinct().ToListAsync();
            return View(aircompanies);
        }

        public IActionResult Baggage()
        {
            return View();
        }

        public async Task<IActionResult> Airports()
        {
            var airports = await _context.Airports.ToListAsync();
            return View(airports);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

