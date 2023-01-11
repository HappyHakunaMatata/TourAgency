using Microsoft.EntityFrameworkCore;
using TourAgency.Models;

namespace TourAgency.Data
{
    public partial class AppDbContext: DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Transfer> Transfers { get; set; }
        public DbSet<Quality> Qualities { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShopCartItem> shopCartItems { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> orderDetails { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<HolidayType> HolidayTypes { get; set; }
        public DbSet<About> abouts { get; set; }
        public DbSet<TicketType> ticketTypes { get; set; }
        public DbSet<Aircompany> aircompanies { get; set; }
        public DbSet<Trip> trips { get; set; }
        public DbSet<RoomService> roomServices { get; set; }
        public DbSet<City> cities { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) :
            base(options)
        {
            Database.EnsureCreated();
        }
    }
}

