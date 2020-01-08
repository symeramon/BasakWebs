using BasakWeb.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasakWeb.Business.Abstract
{
    public interface IOrderService
    {
        List<Order> GetAll();
       
        void Delete(int OrderId);
        Order GetById(int OrderId);
        List<Order> GetAllwithDetails();
        void Add(Order ord);
        void AddOrdDetails(OrderDetails orddetail);
        void SadeSiparisSil(int orderid);
        void SiparisSil(int orderid);
        void SatildiKaldir(int orderid);
    }
}
