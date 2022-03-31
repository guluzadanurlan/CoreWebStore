using System;
using System.Collections.Generic;

#nullable disable

namespace CoreUI.Models
{
    public partial class Laptop
    {
        public Laptop()
        {
            CartItems = new HashSet<CartItem>();
            LaptopPictures = new HashSet<LaptopPicture>();
        }

        public int Id { get; set; }
        public byte? ComputerType { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Cpu { get; set; }
        public string Gpu { get; set; }
        public string Ram { get; set; }
        public string Ssd { get; set; }
        public string Hdd { get; set; }
        public string Monitor { get; set; }
        public string OperatingSystem { get; set; }
        public byte? Weight { get; set; }
        public string ScreenSize { get; set; }
        public int? Price { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<LaptopPicture> LaptopPictures { get; set; }
    }
}
