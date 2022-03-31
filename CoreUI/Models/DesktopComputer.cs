using System;
using System.Collections.Generic;

#nullable disable

namespace CoreUI.Models
{
    public partial class DesktopComputer
    {
        public DesktopComputer()
        {
            CartItems = new HashSet<CartItem>();
            DesktopComputerPictures = new HashSet<DesktopComputerPicture>();
        }

        public int Id { get; set; }
        public byte? ComputerType { get; set; }
        public string Case { get; set; }
        public string MotherBoard { get; set; }
        public string Cpu { get; set; }
        public string Gpu { get; set; }
        public string Ram { get; set; }
        public string Ssd { get; set; }
        public string Hdd { get; set; }
        public string CaseFans { get; set; }
        public string ProcessorCooling { get; set; }
        public string PowerSupply { get; set; }
        public string OperatingSystem { get; set; }
        public string Prize { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<DesktopComputerPicture> DesktopComputerPictures { get; set; }
    }
}
