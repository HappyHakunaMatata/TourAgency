using System;
using System.ComponentModel.DataAnnotations;

namespace TourAgency.Models
{
    public class Hotel
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string? photo { get; set; }
        public bool recomended { get; set; }
        public Region region { get; set; }
        public Quality quality { get; set; }

        public Room? room { get; set; } = new Room();
        public RoomService? roomService { get; set; } = new RoomService();
        public Transfer? transfer { get; set; } = new Transfer();
    }
}

