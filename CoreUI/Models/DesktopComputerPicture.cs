using System;
using System.Collections.Generic;

#nullable disable

namespace CoreUI.Models
{
    public partial class DesktopComputerPicture
    {
        public int Id { get; set; }
        public string DesktopPicPath { get; set; }
        public int? DesktopComuterId { get; set; }

        public virtual DesktopComputer DesktopComuter { get; set; }
    }
}
