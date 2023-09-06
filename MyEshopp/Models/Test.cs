using System.ComponentModel.DataAnnotations;

namespace MyEshopp.Models
{
	public class Test
	{
		[Key]
		public int Id { get; set; }
        public string Name { get; set; }

    }
}
