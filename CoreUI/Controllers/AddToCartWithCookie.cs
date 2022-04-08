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
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections;

namespace CoreUI.Controllers
{
    public class AddToCartWithCookie : Controller
    {
       public class CartSingle
        {
            private CartSingle()
            {

            }

            private static CartSingle obj;
            public static List<CookieList> list;
            public static List<CookieList> GetCartSingle(CookieList par)
            {
                if (obj == null)
                {
                    obj = new CartSingle();
                    list = new List<CookieList>();

                }
                list.Add(par);
                return list;
            }
            
            public void DeleteCartItem(CookieList par){
                    list.Remove(par);
            }

        }




        public ActionResult TestView()
        {
            var a = "[" + HttpContext.Request.Cookies["key"] + "]";

            var data = JsonConvert.DeserializeObject<List<CookieItem>>(a).ToList();

            CookieList obj = new CookieList()
            {
                CookieLists = data
            };
            return View(CartSingle.GetCartSingle(obj));
        }
    }
}