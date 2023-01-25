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
using Microsoft.AspNetCore.Authorization;

namespace TourAgency.Controllers
{
	public class OrderController:Controller
	{
		private readonly ShopCart _shopCart;
        private readonly IOrder _order;

        public OrderController(ShopCart shopCart, IOrder order)
		{
			this._shopCart = shopCart;
			this._order = order;
		}

		public IActionResult CheckOut()
		{
            return View();
        }

        [HttpPost]
        public IActionResult CheckOut(Order order)
        {
            if (!User.Identity.IsAuthenticated)
            {
                ModelState.AddModelError("", "Для дальнейшей покупки необходимо авторизироваться");
            }

            _shopCart.shopCartItems = _shopCart.GetShopCartItems().Result;

            if (_shopCart.shopCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Корзина пуста");
            }
            
            if (ModelState.IsValid)
            {
                _order.CreateOrder(order);
                return RedirectToAction(nameof(Complete));
            }
            return View();
        }

        public IActionResult Clear()
        {
            _shopCart.DeleteShopCartItems();
            _shopCart.shopCartItems = _shopCart.GetShopCartItems().Result;
            if (_shopCart.shopCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Корзина пуста");
            }
            return RedirectToAction("Index","ShopCart");
        }

        public IActionResult Delete(int id)
        {
            _shopCart.DeleteItem(id);
            _shopCart.shopCartItems = _shopCart.GetShopCartItems().Result;
            if (_shopCart.shopCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Корзина пуста");
            }
            return RedirectToAction("Index", "ShopCart");
        }

        
        public IActionResult Complete()
        {
            string message = "Заказ создан!";
            return View("_Complete", message);
        }

    }
}

