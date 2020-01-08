using BasakWeb.Core.DataAccess.EntityFramework;
using BasakWeb.DataAccess.Abstract;
using BasakWeb.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace BasakWeb.DataAccess.Concrete.EntityFramework
{
    public class EFOrderDAL : EfEntityRepositoryBase<Order, BasakWebContext>, IOrderDAL
    {
         BasakWebContext db = new BasakWebContext();

        public void AddDetail(OrderDetails orddetail)
        {
            db.OrderDetails.Add(orddetail);
            db.Entry(orddetail).State = EntityState.Added;
            db.SaveChanges();
        }

        public List<Order> GetListwithDetails()
        {
            return db.Orders.Where(z=> z.Silindi ==false).Include(x => x.Details).ToList();
        }

        public List<Product> GetOrderProducts(int orderid)
        {
            return db.OrderDetails.Where(z => z.OrderId == orderid).Select(x => x.Product).ToList();
        }

        public Order GetWithDetails(int orderId)
        {
            return db.Orders.Where(x=> x.OrderId == orderId).Include(x => x.Details.Select(y=> y.Product)).Include(z=> z.Customer).FirstOrDefault();
        }

        public void SadeSiparisSil(int orderid)
        {
            Order siparis = db.Orders.Where(x => x.OrderId == orderid).FirstOrDefault();
            siparis.Silindi = true;
            db.Entry(siparis).State = EntityState.Modified;

            OrderDetails siparisdetay = db.OrderDetails.Where(x => x.OrderId == orderid).FirstOrDefault();
            if (siparisdetay != null)
            {
                siparisdetay.silindi = true;
                db.Entry(siparisdetay).State = EntityState.Modified;
            }
          
            db.SaveChanges();
        }

        public void SatildiKaldir(int orderid)
        {
            List<Product> products = GetOrderProducts(orderid);
            for (int i = 0; i < products.Count; i++)
            {
                Product prd = products[i];

                prd.Silindi = false;
                var updatedEntity = db.Entry(prd);
                updatedEntity.State = EntityState.Modified;
                db.SaveChanges();

            }
        }

        public void SiparisiSil(int orderid)
        {
            Order ordr = db.Orders.Where(x => x.OrderId == orderid).FirstOrDefault();
            ordr.Silindi = true;
            List<Product> products = GetOrderProducts(orderid);
            for (int i = 0; i < products.Count; i++)
            {
                Product prd = products[i];

                prd.Silindi = true;
                var updatedEntity = db.Entry(prd);
                updatedEntity.State = EntityState.Modified;
               
            }

            var updatedEntity2 = db.Entry(ordr);
            updatedEntity2.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
