using System;
using System.Diagnostics.Metrics;
using System.Net.Sockets;
using TourAgency.Models;

namespace TourAgency.Data.SaveTo
{
	public class AddTrip
	{
        private AppDbContext _context;
        public AddTrip(AppDbContext context)
        {
            _context = context;
        }
        
        public void AddEntity()
        {
            foreach (var i in trips)
            {
                var airlines = _context.aircompanies.FirstOrDefault(model => ((model.name == i.airlines) && (model.airport.name == i.city) && (model.ticketType.name == i.ticket)));
                if (airlines == null)
                {
                    var city = _context.Airports.FirstOrDefault(model => model.name == i.city);
                    var ticketType = _context.ticketTypes.FirstOrDefault(model => model.name == i.ticket);
                    _context.aircompanies.Add(new Models.Aircompany()
                    {
                        name = i.airlines,
                        logo = i.logo,
                        link = i.link,
                        ticketType = ticketType,
                        airport = city
                    });
                    _context.SaveChanges();
                    airlines = _context.aircompanies.FirstOrDefault(model => ((model.name == i.airlines) && (model.airport.name == i.city) && (model.ticketType.name == i.ticket)));
                }
                Trip trip = new Trip()
                {
                    date = i.date,
                    aircompany = airlines
                };
                _context.trips.Add(trip);
            }
            _context.SaveChanges();
        }


        private static List<DataTrip> trips = new()
        {
            new DataTrip()
            {
                date = new DateTime(2022,12,06),
                airlines = "Aeroflot",
                city = "Domodedovo имени Михаила Ломоносова",
                ticket = "Эконом класс",
            },
            new DataTrip()
            {
                date = new DateTime(2023,01,14),
                airlines = "Aeroflot",
                city = "Domodedovo имени Михаила Ломоносова",
                ticket = "Эконом класс",
            },
            new DataTrip()
            {
                date = new DateTime(2022,12,12),
                airlines = "Aeroflot",
                city = "Domodedovo имени Михаила Ломоносова",
                ticket = "Эконом класс",
                
            },
            new DataTrip()
            {
                date = new DateTime(2023,12,05),
                airlines = "Aeroflot",
                city = "Domodedovo имени Михаила Ломоносова",
                ticket = "",
            },
            new DataTrip()
            {
                date = new DateTime(2023,01,27),
                airlines = "Aeroflot",
                city = "Domodedovo имени Михаила Ломоносова",
                ticket = "",
            }
        };

        private class DataTrip
        {
            public DateTime date { get; set; }
            public string airlines { get; set; } = "";
            public string city { get; set; } = "";
            public string ticket { get; set; } = "";
            public string logo { get; set; } = "Aeroflot";
            public string link { get; set; } = "https://www.aeroflot.ru/xx-en";
        }
    }
}

