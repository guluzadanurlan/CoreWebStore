using System.Linq;
using CoreUI.Identity;
using CoreUI.Models;
using CoreUI.Models.ControllerModel;
using CoreUI.Repositories.CartRepository.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using static CoreUI.Controllers.AddToCartWithCookie;

namespace CoreUI.Controllers
{

    public class CartController : Controller
    {
        private ICartService _cartService;
        private UserManager<User> _userManager;
        public CartController(ICartService cartService, UserManager<User> userManager)
        {
            _cartService = cartService;
            _userManager = userManager;
        }
        public IActionResult Index()
        {

            var cart = _cartService.GetCartByUserId(_userManager.GetUserId(User));
            return View(new CartModel()
            {
                CartId = cart.Id,
                CartItems = cart.CartItems.Select(i => new CartItemModel()
                {
                    CartItemId = i.Id,
                    ProductId = i.ProductNavigation.Id,
                    Name = i.ProductNavigation.Brand,
                    Price = (double)i.ProductNavigation.Price,
                    ImageUrl = i.ItemPic.LaptopPicPath,
                    Quantity = (int)i.Quantity

                }).ToList()
            });
        }

        [HttpPost]
        public IActionResult AddToCart(int productId, byte quantity, int itemPicId)
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = _userManager.GetUserId(User);
                _cartService.AddToCart(userId, productId, quantity, itemPicId);
                return RedirectToAction("Index");
            }
            else
            {
                CoreDbContext db = new CoreDbContext();
                var data = db.Laptops.FirstOrDefault(i => i.Id == productId);
                HttpContext.Response.Cookies.Append("key", JsonConvert.SerializeObject(data));



                return RedirectToAction("TestView", "AddToCartWithCookie");
            }
        }

        [HttpPost]
        public IActionResult DeleteFromCart(int productId)
        {
            if (User.Identity.IsAuthenticated)
            {
                var userId = _userManager.GetUserId(User);
                _cartService.DeleteFromCart(userId, productId);
                return RedirectToAction("Index");
            }
            else
            {
               return RedirectToAction("Index");
            }
        }
    }
}