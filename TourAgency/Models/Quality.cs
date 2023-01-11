using System;
using System.ComponentModel.DataAnnotations;

namespace TourAgency.Models
{
	public class Quality
    {
        [Key]
        public int id { get; set; }
        public int value { get; set; }
        public bool super { get; set; }
    }
}

