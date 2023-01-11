using System;
using TourAgency.Data;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace TourAgency.Models
{
	public class ShopCart
	{
		private readonly AppDbContext _context;

		public ShopCart(AppDbContext context)
		{
			_context = context;
		}


		public string ShopCartid { get; set; }
		public List<ShopCartItem> shopCartItems { get; set; }

		public static ShopCart GetCart(IServiceProvider serviceProvider)
		{
			ISession session = serviceProvider.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
			var context = serviceProvider.GetService<AppDbContext>();
			string id = session.GetString("cartID") ?? Guid.NewGuid().ToString();
			session.SetString("cartID", id);
			return new ShopCart(context) { ShopCartid = id };
		}

		public void AddProduct(Product product)
		{
			this._context.shopCartItems.Add(new ShopCartItem
            {
				ShopCartId = ShopCartid,
				product = product
			});
			_context.SaveChanges();
		}

		public async Task<List<ShopCartItem>> GetShopCartItems()
		{
            return await _context.shopCartItems.Where(m => m.ShopCartId == ShopCartid)
                .Include(m => m.product).ThenInclude(m => m.hotel)
                .Include(m => m.product).ThenInclude(m => m.trip)
                .ToListAsync();
		}

        public void DeleteShopCartItems()
        {
			_context.shopCartItems.RemoveRange(this.GetShopCartItems().Result);
			_context.SaveChanges();
        }

        public void DeleteItem(int id)
        {
            var model = _context.shopCartItems.FirstOrDefault(m => m.id == id);
            _context.shopCartItems.Remove(model);
            _context.SaveChanges();
        }
    }
}

