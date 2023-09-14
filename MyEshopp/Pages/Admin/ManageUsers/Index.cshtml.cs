using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyEshopp.Data;
using MyEshopp.Models;

namespace MyEshopp.Pages.Admin.ManageUsers
{
    public class IndexModel : PageModel
    {
        private readonly MyEshopp.Data.MyEshoppContext _context;

        public IndexModel(MyEshopp.Data.MyEshoppContext context)
        {
            _context = context;
        }

        public IList<Users> Users { get;set; }

        public async Task OnGetAsync()
        {
            Users = await _context.Users.ToListAsync();
        }
    }
}
