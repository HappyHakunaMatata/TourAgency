using System;
using TourAgency.Models;

namespace TourAgency.Data.SaveTo
{
	public class AddAirlines
	{
        private AppDbContext _context;
        public AddAirlines(AppDbContext context)
        {
            _context = context;
        }

        public void AddEntity()
        {
            foreach (var i in trips)
            {
                var city = _context.Airports.FirstOrDefault(model => model.name == i.city);
                var ticketType = _context.ticketTypes.FirstOrDefault(model => model.name == i.ticket);

                Aircompany aircompany = new Aircompany()
                {
                    name = i.airlines,
                    logo = i.logo,
                    link = i.link,
                    ticketType = ticketType, 
                    airport = city
                };
                _context.aircompanies.Add(aircompany);
            }
            _context.SaveChanges();
        }

        private static List<DataAirlines> trips = new()
        {
            new DataAirlines()
            {
                city = "Domodedovo имени Михаила Ломоносова",
                ticket = "",
                airlines = "Aeroflot",
            },
            new DataAirlines()
            {
                airlines = "Aeroflot",
                city = "Domodedovo имени Михаила Ломоносова",
                ticket = "Эконом класс",
            }
        };
        private class DataAirlines
        {
            public string airlines { get; set; } = "";
            public string city { get; set; } = "";
            public string ticket { get; set; } = "";
            public string logo { get; set; } = "Aeroflot";
            public string link { get; set; } = "https://www.aeroflot.ru/xx-en";
        }
    }
}

