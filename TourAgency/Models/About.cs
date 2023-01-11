using System;
using System.ComponentModel.DataAnnotations;
using TourAgency.Data.SaveTo;

namespace TourAgency.Models
{
	public class About
    {
        [Key]
        public int id { get; set; }
        public string info { get; set; } = string.Empty;
    }
}

