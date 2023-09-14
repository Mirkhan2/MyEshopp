using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyEshopp.Data;
using MyEshopp.Models;

namespace MyEshopp.Pages.Admin
{
    public class EditModel : PageModel
    {
        private MyEshoppContext _context;
        public EditModel(MyEshoppContext context)
        {
            _context = context;
        }
        [BindProperty]
        public AddEditProductViewModel Product { get; set; }
        public void OnGet(int id)
        {
            var product = _context.Products.Include(p => p.Item)
                  .Where(p => p.Id == id).Select(s => new AddEditProductViewModel
                  {
                      Id = s.Id,
                      Name = s.Name,
                      Description = s.Description,
                      QunatityInStock = s.Item.QuantityInStock,
                      Price = s.Item.Price
                  }).FirstOrDefault();
            Product = product;
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)

                return Page();
            var product = _context.Products.Find(Product.Id);
            var item = _context.Items.First(p => p.Id == product.ItemId);

            product.Name = Product.Name;
            product.Description = Product.Description;
            item.Price = Product.Price;
            item.QuantityInStock = Product.QunatityInStock;

            _context.SaveChanges();

			if (Product.Picture?.Length > 0)
			{
				string filepath = Path.Combine(Directory.GetCurrentDirectory(),
					"wwwrot",
					"images", product.Id + Path.GetExtension(Product.Picture.FileName));
				using (var stream = new FileStream(filepath, FileMode.Create))
				{
					Product.Picture.CopyTo(stream);
				}
			}

			return RedirectToPage("Index");
        }
    }
}
