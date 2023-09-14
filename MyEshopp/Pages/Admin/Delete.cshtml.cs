using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEshopp.Data;
using MyEshopp.Models;

namespace MyEshopp.Pages.Admin
{
	public class DeleteModel : PageModel
	{
		private MyEshoppContext _context;
		public DeleteModel(MyEshoppContext context)
		{
			_context = context;
		}



		[BindProperty]
		public Product Product { get; set; }
		public void OnGet(int id)
		{
			Product = _context.Products.FirstOrDefault(p => p.Id == id);

		}

		public IActionResult OnPost()
		{
			var product = _context.Products.Find(Product.Id);
			var item = _context.Items.First(p => p.Id == product.ItemId);
			_context.Items.Remove(item);
			_context.Products.Remove(product);

			_context.SaveChanges();


			string filepath = Path.Combine(Directory.GetCurrentDirectory(),
				"wwwrot",
				"images",
				product.Id + ".jpg");
			if (System.IO.File.Exists(filepath))
			{
				System.IO.File.Delete(filepath);
			}
			return RedirectToPage("Index");

		}
	}
}
