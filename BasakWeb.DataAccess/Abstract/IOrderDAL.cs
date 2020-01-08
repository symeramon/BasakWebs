using BasakWeb.Core.DataAccess;
using BasakWeb.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasakWeb.DataAccess.Abstract
{
    public interface IOrderDAL : IEntityRepository<Order>//kural solid text file hatırla!!!
    {
        List<Order> GetListwithDetails();
        Order GetWithDetails(int orderId);
        List<Product> GetOrderProducts(int orderid);
        void AddDetail(OrderDetails orddetail);
        void SiparisiSil(int orderid);
        void SadeSiparisSil(int orderid);
        void SatildiKaldir(int orderid);
    }
}
