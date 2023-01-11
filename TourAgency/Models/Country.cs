using System;
using System.ComponentModel.DataAnnotations;

namespace TourAgency.Models
{
    public class Country
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string? flag { get; set; }
    }
}

