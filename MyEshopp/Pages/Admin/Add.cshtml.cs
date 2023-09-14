using System.IO;
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
        public AddEditProductViewModel Product { get; set; }
        public void OnGet()
        {

        }
        public IActionResult OnPost() 
        {
            if(!ModelState.IsValid)
            
                return Page();

            var item = new Item()
            {
                Price = Product.Price,
                QuantityInStock = Product.QunatityInStock
            };
            _context.Add(item);   
            _context.SaveChanges();


            var pro = new Product()
            {
                Name = Product.Name,
                Item = item,
                Description = Product.Description,
            };
            _context.Add(pro);
            _context.SaveChanges();
            pro.ItemId = pro.Id;
            _context.SaveChanges();

            if(Product.Picture?.Length> 0)
            {
                string filepath = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwrot",
                    "images", pro.Id +Path.GetExtension(Product.Picture.FileName ));
                using (var stream = new FileStream(filepath,FileMode.Create))
                {
                    Product.Picture.CopyTo(stream);
                }
            }

            return RedirectToPage("Index");
            
        }
    }
}
