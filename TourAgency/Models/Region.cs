using System;
using System.ComponentModel.DataAnnotations;

namespace TourAgency.Models
{
	public class Region
	{
        [Key]
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public Country country { get; set; }
    }
}

