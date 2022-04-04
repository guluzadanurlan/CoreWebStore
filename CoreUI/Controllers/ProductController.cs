using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoreUI.Models;
using Microsoft.EntityFrameworkCore;
using CoreUI.Models.ControllerModel;

namespace CoreUI.Controllers
{
    public class ProductController : Controller
    {


        public IActionResult GetProduct(string Brand)
        {
            CoreDbContext db = new CoreDbContext();
            
            var data=db.LaptopPictures.Include("Laptop").Where(i=>i.Laptop.Brand==Brand).ToList();
            return View(data);
        }
         public IActionResult SearchProduct(string par)
        {
            
            CoreDbContext db = new CoreDbContext();
            
            var data=db.LaptopPictures.Include("Laptop").Where(
                 i=>i.Laptop.Brand==par|| i.Laptop.Model==par|| i.Laptop.Cpu==par
                ).ToList();
            return View(data);
        }

        public int RetInt(int a){
            a=100;
            return a;
        }

    }
}
