using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyEshopp.Data;
using MyEshopp.Models;

namespace MyEshopp.Pages.Admin
{
    public class IndexModel : PageModel
    {
	    private	MyEshoppContext _context;
		public IndexModel(MyEshoppContext context)
        {
            _context = context;
        }
        public IEnumerable<Product> products { get; set; }

		public void OnGet()
        {
          products = _context.Products.Include(p => p.Item);
        }
		public void OnPost()
		{
           
		}
	}
}
