using System.Collections.Generic;

namespace MyEshopp.Models
{
	public class Product
	{

		public int Id { get; set; }
       

        public string Name { get; set; }

		public string Description { get; set; }

		public int ItemId { get; set; }
		public Item Item { get; set; }

		public ICollection<CatagoryToProduct> CatagoryToProducts { get; set; }



	}
}
