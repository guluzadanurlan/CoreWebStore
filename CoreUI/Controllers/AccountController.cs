using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CoreUI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using CoreUI.Identity;
using Microsoft.AspNetCore.Http;
using CoreUI.HelpFolder;
using CoreUI.Models.ControllerModel;
using CoreUI.Repositories.Abstract;
using CoreUI.Repositories.CartRepository.Abstract;

namespace CoreUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;

        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private ICartService _cartservice;
      
        public AccountController(ICartService cartservice, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _cartservice=cartservice;
            _userManager = userManager;
            _signInManager = signInManager;
        }

       // ****************************************Login*************************************//
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await _userManager.FindByNameAsync(model.UserName);

         //   HttpContext.Session.SetString("UserName", model.UserName);
            if (user == null)
            {
                ModelState.AddModelError("", "Sizin Hesabiniz yoxdur qeydiyyatdan kecin");
                return View(model);
            }
            // if (!await _userManager.IsEmailConfirmedAsync(user))
            // {
            //     ModelState.AddModelError("", "Hesabinizi mail-iz ile tesdiq edin");
            //     return View(model);
            // }

            var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);
            if (result.Succeeded)
            {
               // HttpContext.Session.SetString("Id",user.Id);
                TempData.Put("message", new AlertMessage()
                {
                    Title="Xos geldiniz",
                    Message="Xos geldiniz "+model.UserName+_userManager.GetUserId(User),
                    AlertType="success"
                });
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

      
        //----------------------------------------------------------------------------------------------//

   
         //*********************************Register************************//
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new User()
            {
                Name = model.Name,
                LastName = model.LastName,
                UserName = model.UserName,
                Email=model.Email,
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            //UnitOfWork unitofwork = new UnitOfWork(new CoreDbContext());
            
           //  UsersPhoto dbUserPhoto = new UsersPhoto();
           //   dbUserPhoto.UserId = user.Id;
           //  dbUserPhoto.PhotoPath = UploadImage.Add(par);
           // unitofwork.UserPhotoRepository.Add(dbUserPhoto);
           //unitofwork.Complete();//UserPhooto data send database
             if (result.Succeeded)
             {
                 _cartservice.InitializeCart(user.Id);
            //     // generate token
            //     var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            //     var url = Url.Action("ConfirmEmail", "Account", new
            //     {
            //         userId = user.Id,
            //         token = code
            //     });

            //     // email
            //    // await _emailSender.SendEmailAsync(model.Email, "Hesabinizi tesdiqlemek ucun", $"https://localhost:5001{url}'> linke</a> daxil olun");
            //     //with Tempdata message
            //    TempData.Put("message", new AlertMessage()
            //     {
            //         Title="Ugurla qeydiyyatdan kecdiniz",
            //         Message="Mail-iz ile hesabinizi tesdiq edin",
            //         AlertType="success"
            //     });
                return RedirectToAction("Login", "Account");
             }

          //  ModelState.AddModelError("", "Namelum xeta bas verdi");
            return View(model);
        }
       //****************************************************************
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
