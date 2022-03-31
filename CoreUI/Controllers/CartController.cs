using System.Linq;
using CoreUI.Identity;
using CoreUI.Models;
using CoreUI.Models.ControllerModel;
using CoreUI.Repositories.CartRepository.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoreUI.Controllers
{
   
    public class CartController:Controller
    {
        private ICartService _cartService;
        private UserManager<User> _userManager;
        public CartController(ICartService cartService,UserManager<User> userManager)
        {
            _cartService = cartService;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            var cart = _cartService.GetCartByUserId("4c5d4e01-ea67-4c8e-9bc6-904acb57affd");
            return View(new CartModel(){
                CartId = cart.Id,
                CartItems = cart.CartItems.Select(i=>new CartItemModel()
                {
                    CartItemId = i.Id,
                    ProductId = i.ProductNavigation.Id,
                    Name = i.ProductNavigation.Brand,
                    Price = (double)i.ProductNavigation.Price,
                    ImageUrl = i.ItemPic.LaptopPicPath,
                    Quantity =(int)i.Quantity

                }).ToList()
            });
        } 

        [HttpPost]
        public IActionResult AddToCart(int productId,byte quantity)
        {
            var userId = _userManager.GetUserId(User);
            _cartService.AddToCart(userId,productId,quantity);
            return RedirectToAction("Index");
        } 
    }
}