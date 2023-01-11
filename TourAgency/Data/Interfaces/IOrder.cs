using System;
using TourAgency.Models;

namespace TourAgency.Data.Interfaces
{
	public interface IOrder
	{
		public void CreateOrder(Order order);
    }
}

