﻿using System.Collections.Generic;

namespace MyEshopp.Models
{
    public class CartViewModel
    {
        public CartViewModel()
        {
            CartItems = new List<CartItem>();
        }
        public List<CartItem>  CartItems{ get; set; }
        public decimal OrderTotal { get; set; }
    }
}
