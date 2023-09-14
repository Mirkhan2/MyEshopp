using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace MyEshopp.Models
{
	public class Order
	{
		[Key]
		public int OrderId { get; set; }
		[Required]
		public int UserId { get; set; }
		[Required]
		public DateTime CreateDate { get; set; }
		public bool IsFinaly { get; set; }

		[ForeignKey("userId")]
		public Users Users { get; set; }
		public List<OrderDetail> OrderDetails { get; set; }

		//public static implicit operator Task<object>(Order v)
		//{
		//	throw new NotImplementedException();
		//}
	}
}
