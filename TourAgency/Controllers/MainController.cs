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
using TourAgency.Services.Interfaces;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TourAgency.Services.Models;


namespace TourAgency.Controllers
{
    public class MainController:Controller
    {
        private readonly IOffer _offer;
        private readonly AppDbContext _context;

        public MainController(IOffer offer, AppDbContext context)
        {
            _offer = offer;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<Product> product = await _context.Products
                .Include(h => h.hotel).ThenInclude(r => r.roomService)
                .Include(h => h.hotel).ThenInclude(r => r.room)
                .Include(h => h.hotel).ThenInclude(r => r.quality)
                .Include(h => h.hotel).ThenInclude(r => r.transfer)
                .Include(h => h.hotel).ThenInclude(r => r.region)
                .Include(p => p.about)
                .Include(p => p.holidayType)
                .Include(p => p.trip).ThenInclude(a => a.aircompany).ThenInclude(a => a.airport).ThenInclude(a => a.city)
                .ToListAsync();
            
            return View(product);
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

        public IActionResult Development()
        {
            return View();
        }
    }
}

