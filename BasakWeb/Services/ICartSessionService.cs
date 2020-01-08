using BasakWeb.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasakWeb.Business.Abstract
{
    public interface ICartSessionService
    {
        Cart GetCart();
        void SetCart(Cart cart);
    }
}
