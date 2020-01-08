using BasakWeb.Business.Abstract;
using BasakWeb.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasakWeb.Services
{
    public class CartSessionService:ICartSessionService
    {
        public Cart GetCart()
        {
            Cart cartToCheck = HttpContext.Current.Session["cart"] as Cart;
            if (cartToCheck == null)
            {
                HttpContext.Current.Session["cart"] = new Cart();
                cartToCheck = HttpContext.Current.Session["cart"] as Cart;
            }
            return cartToCheck;
        }

        public void SetCart(Cart cart)
        {
            HttpContext.Current.Session["cart"] = cart;
        }
    }
}