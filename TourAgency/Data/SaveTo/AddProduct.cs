using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using TourAgency.Models;

namespace TourAgency.Data.SaveTo
{
	public class AddProduct
	{
        private AppDbContext _context;
        public AddProduct(AppDbContext context)
		{
            _context = context;
        }
        
        public void AddEntity()
        {
            foreach (var i in products)
            {
                var hotel = _context.Hotels.FirstOrDefault(model => model.name == i.hotel);
                var holidayType = _context.HolidayTypes.FirstOrDefault(model => model.name == i.type);
                var about = _context.abouts.FirstOrDefault(model => model.info == i.info);
                var trip = _context.trips.FirstOrDefault(model => model.date == i.date);

                Product product = new Product()
                {
                    hotel = hotel,
                    holidayType = holidayType,
                    about = about,
                    trip = trip,
                    duration = i.duration,
                    price = i.price
                };
                _context.Products.Add(product);
            }
            _context.SaveChanges();
        }

        private static List<DataProduct> products = new()
        {
            new DataProduct()
            {
                photo = "Malahini Kuda Bandos Resort.jpeg",
                hotel = "Malahini Kuda Bandos Resort",
                quality = 4,

                room = "Delux",
                transfer = "Катер",
                service = "Завтрак буфет",

                info = "полная стоимость на двоих",
                type = "Пляжный",


                date = new DateTime(2022,12,06),
                airlines = "Aeroflot",
                city = "Москва",
                ticket = "Эконом класс",
                name = "Мале",


                duration = 9,
                price = 379124,
            },
            new DataProduct()
            {
                photo = "Sun Siyam Iru Fushi Maldives.jpeg",
                name = "Мале",
                date = new DateTime(2023,01,14),
                hotel = "Sun Siyam Iru Fushi Maldives",
                quality = 5,
                airlines = "Aeroflot",
                city = "Москва",
                ticket = "Эконом класс",
                room = "DELUXE BEACH VILLA",
                transfer = "Самолет + Катер",
                duration = 11,
                service = "Завтрак буфет",
                price = 670350,
                info = "полная стоимость на двоих",
                type = "Пляжный"
            },
            new DataProduct()
            {
                photo = "Nika Island Maldives.jpeg",
                name = "Мале",
                date = new DateTime(2022,12,12),
                hotel = "Nika Island Maldives",
                quality = 5,
                airlines = "Aeroflot",
                city = "Москва",
                ticket = "Эконом класс",
                room = "BEACH VILLA",
                transfer = "Гидро самолет",
                duration = 8,
                service = "Полный пансион",
                price = 412760,
                info = "полная стоимость на двоих",
                type = "Пляжный"
            },
            new DataProduct()
            {
                photo = "Sun Siyam World Maldives.jpeg",
                name = "Мале",
                date = new DateTime(2023,12,05),
                hotel = "Sun Siyam World Maldives",
                quality = 5,
                airlines = "Aeroflot",
                city = "Москва",
                ticket = "",
                room = "WATER VILLA WITH POOL AND SLIDE",
                transfer = "Самолет + Катер",
                duration = 10,
                service = "Все включено",
                price = 477738,
                info = "полная стоимость на двоих",
                type = "Пляжный"
            },
            new DataProduct()
            {
                photo = "LUX* South Ari Atoll, Maldives.jpeg",
                name = "Мале",
                date = new DateTime(2023,01,27),
                hotel = "LUX* South Ari Atoll, Maldives",
                quality = 5,
                airlines = "Aeroflot",
                city = "Москва",
                ticket = "",
                room = "BEACH VILLA",
                transfer = "Гидро самолет",
                duration = 12,
                service = "Завтрак буфет",
                price = 412760,
                info = "полная стоимость на двоих",
                type = "Пляжный"
            }
        };

        private class DataProduct
        {
            public decimal duration { get; set; }
            public uint price { get; set; }
            public DateTime date { get; set; }
            public string airlines { get; set; } = "";
            public string city { get; set; } = "";
            public string ticket { get; set; } = "";
            public string name { get; set; } = "";
            public int quality { get; set; }
            public string photo { get; set; } = "";
            public string hotel { get; set; } = "";
            public string room { get; set; } = "";
            public string transfer { get; set; } = "";
            public string service { get; set; } = "";
            public string info { get; set; } = "";
            public string type { get; set; } = "";
        }
    }
}

