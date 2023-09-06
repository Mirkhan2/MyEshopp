    using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyEshopp.Data;
using MyEshopp.Models;

namespace MyEshopp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MyEshoppContext _context;
        private static Cart _cart = new Cart();



        public HomeController(ILogger<HomeController> logger , MyEshoppContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
		}
        public IActionResult Details(int id)
        {
            var product = _context.Products.Include(p => p.Item)
                .SingleOrDefault(p => p.Id == id);

				

            if (product == null)
            {
                return NotFound();
            }
            var catagories = _context.Products
                .Where (p => p.Id == id).SelectMany(c => c.CatagoryToProducts)
                .Select(ca => ca.Catagory)
                .ToList();

            var vm = new DetailsViewModel()
            {
               Product = product,
               Catagories = catagories

            };
            

            return View(vm);
        }
        public IActionResult AddToCart(int itemId)
        {
            var product = _context.Products.Include(p => p.Item).SingleOrDefault(p => p.ItemId == itemId);
            if (product != null)
            {
                var cartItem = new CartItem()
                {
                    Item = product.Item,
                    Quantity = 1
                };
                _cart.addItem(cartItem);
            }
            return RedirectToAction("ShowCart");
        }
        public IActionResult ShowCart()
        {
            var CartVM = new CartViewModel()
            {
                CartItems = _cart.CartItems,
                OrderTotal = _cart.CartItems.Sum(c => c.getTotalPrice())
                 };
            return View(CartVM);
        }
        public IActionResult RemoveCart(int itemId) 
        {
            _cart.RemoveCartItem(itemId);
            return RedirectToAction("ShowCart");
        }


        [Route("ContactUs")]
        public IActionResult ContactUs()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
