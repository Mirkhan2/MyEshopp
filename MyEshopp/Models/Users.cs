using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace MyEshopp.Models
{
	public class Users
	{
        //sefat
       
        public int UserId { get; set; }

		[Required]
		[MaxLength(300)]

		public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }

        [Required]
        public DateTime  Registerdate { get; set; }

        public bool IsAdmin { get; set; }

        public List<Order> Orders { get; set; }
    }
}
