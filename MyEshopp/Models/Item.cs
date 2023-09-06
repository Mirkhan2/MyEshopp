namespace MyEshopp.Models
{
    public class Item
    {
        public int Id { get; set; }
		public Product Product { get; set; }

		public decimal Price { get; set; }
        public int QuantityInStock{ get; set; }
		
	}
}
