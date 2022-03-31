using System;
using System.Collections.Generic;



namespace CoreUI.Models
{
    public class ComputersAndPhoto
    {

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
        public string LaptopPicPath { get; set; }

    }
}
