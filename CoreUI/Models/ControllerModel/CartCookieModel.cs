using System.Collections.Generic;
using System.Linq;

namespace CoreUI.Models.ControllerModel
{




    public class CookieList
    {
        public List<CookieItem> CookieLists { get; set; }
    }

    public class CookieCart
    {
        public List<CookieList> CookieCarts { get; set; }
    }
    public class CookieItem
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
    }
}