using System;
using TourAgency.Models;
using TourAgency.Data.Interfaces;

namespace TourAgency.Data.Repositories
{
	public class OrderRepository : IOrder
    {
		private readonly AppDbContext _context;
        private readonly ShopCart _shopCart;

		public OrderRepository(AppDbContext context, ShopCart shopCart)
        {
            this._context = context;
            this._shopCart = shopCart;
        }

        public void CreateOrder(Order order)
        {
            order.date = DateTime.Now;
            order.orderDetails = new List<OrderDetail>();
            var models = _shopCart.shopCartItems;
            foreach(var i in models)
            {
                var orderDetail = new OrderDetail()
                {
                    ProductID = i.product.id,
                    orderID = order.id,
                    price = i.product.price
                };
                order.orderDetails.Add(orderDetail);
            }

            _context.Orders.Add(order);
            _context.SaveChanges();
        }
    }
}

