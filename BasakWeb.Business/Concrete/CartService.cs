using BasakWeb.Business.Abstract;
using BasakWeb.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BasakWeb.Business.Concrete
{
    public class CartService : ICartService
    {
        public bool AddToCart(Cart cart, Product product)
        {
            CartLine cartline = cart.CartLines.FirstOrDefault(c => c.Product.ProductId == product.ProductId);
            if (cartline == null)
            {
                //cartline.Quantity++;
                //return;
                cart.CartLines.Add(new CartLine { Product = product, Quantity = 1 });
                return true;
            }
            return false;
        }

        public List<CartLine> List(Cart cart)
        {
            return cart.CartLines;
        }

        public void RemoveFromCart(Cart cart, int productid)
        {
            cart.CartLines.Remove(cart.CartLines.FirstOrDefault(c => c.Product.ProductId == productid));

        }
    }
}
