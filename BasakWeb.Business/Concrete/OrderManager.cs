using BasakWeb.Business.Abstract;
using BasakWeb.DataAccess.Abstract;
using BasakWeb.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasakWeb.Business.Concrete
{
    public class OrderManager : IOrderService
    {
        private IOrderDAL _orderDal;
        private IProductDAL _productdal;
        public OrderManager(IOrderDAL orderDal,IProductDAL productDAL)
        {
            _orderDal = orderDal;
            _productdal = productDAL;
        }

        public void Add(Order ord)
        {
            _orderDal.Add(ord);
        }

        public void AddOrdDetails(OrderDetails orddetail)
        {
            _orderDal.AddDetail(orddetail);
        }

        public void Delete(int OrderId)
        {
            throw new NotImplementedException();
        }

        public List<Order> GetAll()
        {
            return _orderDal.GetList();
        }

        public List<Order> GetAllwithDetails()
        {
            return _orderDal.GetList();
        }

        public Order GetById(int OrderId)
        {
            return _orderDal.GetWithDetails(OrderId);
        }

        public void SadeSiparisSil(int orderid)
        {

            _orderDal.SadeSiparisSil(orderid);
        }

        public void SatildiKaldir(int orderid)
        {
            _orderDal.SatildiKaldir(orderid);
        }

        public void SiparisSil(int orderid)
        {
            _orderDal.SiparisiSil(orderid);
        }
    }
}
