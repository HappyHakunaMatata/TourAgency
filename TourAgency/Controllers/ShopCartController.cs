using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TourAgency.ViewModels;
using TourAgency.Data.Interfaces;
using TourAgency.Data.SaveTo;
using Microsoft.EntityFrameworkCore;
using TourAgency.Data;
using TourAgency.Models;
using System.Collections.Generic;


namespace TourAgency.Controllers
{
	public class ShopCartController : Controller
	{

		private readonly AppDbContext _context;
		private readonly ShopCart _shopCart;


		public ShopCartController(AppDbContext context, ShopCart shopCart)
		{
			_context = context;
			_shopCart = shopCart;
		}

        public IActionResult Index()
        {
			var items = _shopCart.GetShopCartItems();
			_shopCart.shopCartItems = items.Result;

			var model = new ShopCartViewModel()
			{
				shopCart = _shopCart
			};
            return View(model);
        }

        public RedirectToActionResult AddToCart(int id)
        {
			var product = _context.Products.Find(id);
			if (product != null)
			{
                _shopCart.AddProduct(product);
			}
            return RedirectToAction(nameof(Index));
        }
    }
}

