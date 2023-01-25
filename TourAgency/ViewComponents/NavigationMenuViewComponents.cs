using System;
using System.Collections.Generic;
using System.Security.Claims;
using Google.Apis.Auth.AspNetCore3;
using Google.Apis.PeopleService.v1;
using Google.Apis.PeopleService.v1.Data;
using Google.Apis.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TourAgency.Controllers;
using TourAgency.Data;
using TourAgency.Models;
using TourAgency.ViewModels;

namespace TourAgency.ViewComponents
{

    public class NavigationMenuViewComponent : ViewComponent
    {
        private readonly AppDbContext _context;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _UserManager;

        public NavigationMenuViewComponent(AppDbContext context, SignInManager<IdentityUser> signInManager,
            UserManager<IdentityUser> UserManager)
        {
            _context = context;
            _signInManager = signInManager;
            _UserManager = UserManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            NavigationMenuViewModel navigationMenuViewModel = new NavigationMenuViewModel()
            {
                countries = _context.Countries.OrderByDescending(m => m.id).Take(10).ToList()
            };
            await IsAuthenticated(navigationMenuViewModel);
            return View(navigationMenuViewModel);
        }

        public async Task IsAuthenticated(NavigationMenuViewModel navigationMenuViewModel)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                var name = HttpContext.Session.GetString("Name");
                ClaimsPrincipal claimsPrincipal = HttpContext.User;
                if (name != null)
                {
                    navigationMenuViewModel.name = name;
                    navigationMenuViewModel.photo = HttpContext.Session.GetString("Photo");
                }
                else
                {
                    navigationMenuViewModel.name = HttpContext.User.Identity.Name;
                    navigationMenuViewModel.photo = "/img/user-icon.svg";
                }
            }
            else
            {
                Console.WriteLine("Is not authenticated");
            }
        }
    }
}

