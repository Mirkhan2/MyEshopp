using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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




		public HomeController(ILogger<HomeController> logger, MyEshoppContext context)
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
				.Where(p => p.Id == id).SelectMany(c => c.CatagoryToProducts)
				.Select(ca => ca.Catagory)
				.ToList();

			var vm = new DetailsViewModel()
			{
				Product = product,
				Catagories = catagories

			};


			return View(vm);
		}
		[Authorize]
		public IActionResult AddToCart(int itemId)
		{
			var product = _context.Products.Include(p => p.Item).SingleOrDefault(p => p.ItemId == itemId);
			if (product != null)
			{

				int userId =int.Parse(User.FindFirst(ClaimTypes.NameIdentifier).ToString());
				var order = _context.Orders.FirstOrDefault(o => o.UserId == userId && !o.IsFinaly);
				if (order != null)
				{
					var orderDetail =
						_context.OrderDetails.FirstOrDefault(d =>
						d.OrderId == order.OrderId && d.ProductId == product.Id);
					if (orderDetail != null)
					{
						orderDetail.Count += 1;
					}
				}
				else
				{
					order = new Order()
					{
						
						IsFinaly = false,
						CreateDate = DateTime.Now,
						UserId = userId

					};
					_context.Orders.Add(order);
					_context.SaveChanges();
					_context.OrderDetails.Add(new OrderDetail()
					{
						OrderId = order.OrderId,
						ProductId = product.Id,
						Price = product.Item.Price
					});
				}
				_context.SaveChanges();


			}
			return RedirectToAction("ShowCart");
		}
		[Authorize]
		public IActionResult ShowCart()
		{
			int userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
			var order = _context.Orders.Where(o => o.UserId == userId!&& o.IsFinaly)
				.Include(o => o.OrderDetails)
				.ThenInclude(c => c.Product).FirstOrDefault();
			return View(order);
		}
		[Authorize]
		public IActionResult RemoveCart(int detailId)
		{

			var OrderDetail = _context.OrderDetails.Find(detailId);
			_context.Remove(OrderDetail);
			_context.SaveChanges();
			
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
