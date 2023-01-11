using System;
using Microsoft.EntityFrameworkCore;
using TourAgency.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;



namespace TourAgency.Data
{
	public class AuthDbContext : IdentityDbContext
	{
		public AuthDbContext(DbContextOptions<AuthDbContext> options) :
            base(options)
        {
            Database.EnsureCreated();
        }

    }
}

