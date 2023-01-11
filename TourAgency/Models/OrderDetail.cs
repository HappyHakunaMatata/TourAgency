using System;
using System.ComponentModel.DataAnnotations;

namespace TourAgency.Models
{
	public class OrderDetail
	{
        [Key]
        public int id { get; set; }
		public int orderID { get; set; }
		public int ProductID { get; set; }
		public uint price { get; set; }
		public Product product { get; set; }
        public Order order { get; set; }
    }
}

