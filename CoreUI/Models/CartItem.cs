using System;
using System.Collections.Generic;

#nullable disable

namespace CoreUI.Models
{
    public partial class CartItem
    {
        public int Id { get; set; }
        public int? CartId { get; set; }
        public int? ProductId { get; set; }
        public byte? Quantity { get; set; }
        public int? ItemPicId { get; set; }

        public  Cart Cart { get; set; }
        public  LaptopPicture ItemPic { get; set; }
        public  DesktopComputer Product { get; set; }
        public  Laptop ProductNavigation { get; set; }
    }
}
