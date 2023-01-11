using System;
using System.ComponentModel.DataAnnotations;

namespace TourAgency.Models
{
	public class Trip
	{
        [Key]
        public int id { get; set; }
        public Aircompany aircompany { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime date { get; set; }
    }
}

