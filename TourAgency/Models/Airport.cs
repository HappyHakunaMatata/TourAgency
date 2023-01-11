using System;
using System.ComponentModel.DataAnnotations;

namespace TourAgency.Models
{
    public class Airport
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string symbol {get; set; } = string.Empty;
        public string link { get; set; } = string.Empty;
        public City city { get; set; }
    }
}

