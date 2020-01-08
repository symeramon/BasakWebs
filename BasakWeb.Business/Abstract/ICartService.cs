using BasakWeb.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace BasakWeb.Business.Abstract
{
    public interface ICartService
    {
        bool AddToCart(Cart cart, Product product);
        void RemoveFromCart(Cart cart, int productid);
        List<CartLine> List(Cart cart);
    }
}
