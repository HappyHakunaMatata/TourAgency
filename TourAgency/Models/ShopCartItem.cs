using System;
namespace TourAgency.Models
{
	public class ShopCartItem
	{
		public int id { get; set; }
		public Product product { get; set; }

		public string ShopCartId { get; set; }
	}
}

