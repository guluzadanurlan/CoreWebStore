using System;
using System.Collections.Generic;

#nullable disable

namespace CoreUI.Models
{
    public partial class ComputerType
    {
        public int Id { get; set; }
        public byte? LaptopComputer { get; set; }
        public byte? DesktopComputer { get; set; }
    }
}
