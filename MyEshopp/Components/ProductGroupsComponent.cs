using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyEshopp.Data;

namespace MyEshopp.Components
{
    public class ProductGroupsComponent : ViewComponent
    {
        private MyEshoppContext _context;

        public ProductGroupsComponent(MyEshoppContext context)
        {
            _context = context;

            
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("/Views/Components/ProductGroupsComponent.cshtml", _context.Catagories);
        }
    }
}
