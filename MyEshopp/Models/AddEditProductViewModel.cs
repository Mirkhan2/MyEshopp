using Microsoft.AspNetCore.Http;

namespace MyEshopp.Models
{
    public class AddEditProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string  Description { get; set; }
        public decimal Price { get; set; }
        public int QunatityInStock { get; set; }
        public IFormFile Picture { get; set; }
    }
}
