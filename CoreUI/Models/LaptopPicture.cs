using System;
using System.Collections.Generic;

#nullable disable

namespace CoreUI.Models
{
    public partial class LaptopPicture
    {
        public LaptopPicture()
        {
            CartItems = new HashSet<CartItem>();
        }

        public int Id { get; set; }
        public string LaptopPicPath { get; set; }
        public int? LaptopId { get; set; }

        public virtual Laptop Laptop { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
