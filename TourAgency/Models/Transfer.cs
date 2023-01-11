using System;
using System.ComponentModel.DataAnnotations;
using TourAgency.Data.SaveTo;

namespace TourAgency.Models
{
    public class Transfer 
    {
        [Key]
        public int id { get; set; }
        public string type { get; set; } = string.Empty;
    }
}

