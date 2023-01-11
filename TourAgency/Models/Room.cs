using System;
using System.ComponentModel.DataAnnotations;
using TourAgency.Data.SaveTo;

namespace TourAgency.Models
{
	public class Room 
    {
        [Key]
        public int id { get; set; }
        public string room { get; set; } = string.Empty;
    }
}

