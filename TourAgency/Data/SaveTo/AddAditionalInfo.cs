using System;
using TourAgency.Models;

namespace TourAgency.Data.SaveTo
{
    public class AddAditionalInfo
    {
        private AppDbContext _context;
        public AddAditionalInfo(AppDbContext context)
        {
            _context = context;
        }

        private static List<HolidayType> holidayTypes = new()
        {
            new HolidayType() {name = "Пляжный"}
        };

        private static List<About> about = new()
        {
            new About() {info = "полная стоимость на двоих"}
        };

        private static List<RoomService> service = new()
        {
            new RoomService() {name = "Завтрак буфет"},
            new RoomService() {name = "Полный пансион"},
            new RoomService() {name = "Все включено"},
        };

        private static List<Transfer> transfers = new()
        {
            new Transfer() {type = "Гидро самолет"},
            new Transfer() {type = "Самолет + Катер"},
            new Transfer() {type = "Катер"},
            new Transfer() {type = "Самолет + Лодка"},
        };

        private static List<Room> rooms = new()
        {
            new Room() {room = "Delux"},
            new Room() {room = "DELUXE BEACH VILLA"},
            new Room() {room = "BEACH VILLA"},
            new Room() {room = "WATER VILLA WITH POOL AND SLIDE"},
            new Room() {room = "BEACH PAVILION"},
            new Room() {room = "DELUXE BEACH BUNGALOW"},
            new Room() {room = "SUPERIOR"},
        };

        private static List<TicketType> tickets = new()
        {
            new TicketType() {name = "Эконом класс"},
            new TicketType() {name = "Бизнес класс"},
            new TicketType() {name = "Первый класс"},
            new TicketType() {name = "Империал класс"},
            new TicketType() {name = ""},
        };

        public void AddEntity()
        {
            foreach (var i in tickets)
            {
                _context.Set<TicketType>().Add(i);
            }
            foreach (var i in rooms)
            {
                _context.Set<Room>().Add(i);
            }
            foreach (var i in transfers)
            {
                _context.Set<Transfer>().Add(i);
            }
            foreach (var i in service)
            {
                _context.Set<RoomService>().Add(i);
            }

            foreach (var i in about)
            {
                _context.Set<About>().Add(i);
            }
            foreach (var i in holidayTypes)
            {
                _context.Set<HolidayType>().Add(i);
            }
            _context.SaveChanges();
        }
    }
}

