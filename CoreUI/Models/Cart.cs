using System;
using System.Collections.Generic;

#nullable disable

namespace CoreUI.Models
{
    public partial class Cart
    {
        public Cart()
        {
            CartItems = new List<CartItem>();
        }

        public int Id { get; set; }
        public string UserId { get; set; }

        public virtual AspNetUser User { get; set; }
        public virtual List<CartItem> CartItems { get; set; }
    }
}
