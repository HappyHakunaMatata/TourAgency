using System;
using System.ComponentModel.DataAnnotations;
using TourAgency.Data.SaveTo;

namespace TourAgency.Models
{
	public class Aircompany
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string? logo { get; set; }
        public string link { get; set; }
        public TicketType?  ticketType { get; set; }
        public Airport? airport { get; set; }
    }
}

