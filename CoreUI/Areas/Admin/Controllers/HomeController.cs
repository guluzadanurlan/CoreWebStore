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

namespace CoreUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {


        public IActionResult Index()
        {

            return View();
        }

        public IActionResult TableEdit()
        {
            CoreDbContext obj = new CoreDbContext();
           
            return View( obj.UserPhotos.Include("User").ToList());
        }
    }
}
