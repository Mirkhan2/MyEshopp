using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyEshopp.Data;
using MyEshopp.Models;

namespace MyEshopp.Pages.Admin
{
	public class AddModel : PageModel
	{
		private MyEshoppContext _context;
		public AddModel(MyEshoppContext context)
		{
			_context = context;
		}

		[BindProperty]

		public AddEditProductViewModel product { get; set; }

		[BindProperty]
		public List<int> selectedGroups { get; set; }
		public void OnGet()
		{
			product = new AddEditProductViewModel()
			{
				Catagories = _context.Catagories.ToList(),

			};
		}
		public IActionResult OnPost()
		{
			if (!ModelState.IsValid)

				return Page();

			var item = new Item()
			{
				Price = product.Price,
				QuantityInStock = product.QunatityInStock
			};
			_context.Add(item);
			_context.SaveChanges();


			var pro = new Product()
			{
				Name = product.Name,
				Item = item,
				Description = product.Description,
			};
			_context.Add(pro);
			_context.SaveChanges();
			pro.ItemId = pro.Id;
			_context.SaveChanges();

			if (product.Picture?.Length > 0)
			{
				string filepath = Path.Combine(Directory.GetCurrentDirectory(),
					"wwwrot",
					"images", pro.Id + Path.GetExtension(product.Picture.FileName));
				using (var stream = new FileStream(filepath, FileMode.Create))
				{
					product.Picture.CopyTo(stream);
				}
			}

			if (selectedGroups.Any() && selectedGroups.Count > 0)
			{
				foreach (int gr in selectedGroups)
				{
					_context.CatagoryToProducts.Add(new CatagoryToProduct()
					{
						CatagoryId = gr,
						ProductId = pro.Id


					});
				}
				_context.SaveChanges();
			}
			return RedirectToPage("Index");
		}
			
		}
	}
