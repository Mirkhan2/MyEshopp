using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyEshopp.Data;
using MyEshopp.Models;

namespace MyEshopp.Controllers
{
	public class ProductController : Controller
	{
		MyEshoppContext _context;
        public ProductController(MyEshoppContext context)
        {
            _context = context;
        }

		[Route("Group/{id}/{name}")]
        public IActionResult ShowProductByGroupId(int id, string name)
		{
				ViewData["GroupName"]=name;
				//ViewData["Name"]="nyma";
			
			var products = _context.CatagoryToProducts
				.Where(c => c.CatagoryId == id )
				.Include(c => c.Product)
				.ToList();
			return View(products);
		}
	}
}
