using System;
using TourAgency.Models;
using Google.Apis.Auth.AspNetCore3;
using Google.Apis.PeopleService.v1;
using Google.Apis.PeopleService.v1.Data;
using Google.Apis.Services;

namespace TourAgency.ViewModels
{
	public class NavigationMenuViewModel
	{
		public List<Country> countries { get; set; }
		public string name { get; set; }
		public string photo { get; set; } = "/img/user-icon.svg";
    }
}

