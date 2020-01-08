
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using BasakWeb.Core.DataAccess.EntityFramework;
using BasakWeb.DataAccess.Abstract;
using BasakWeb.Entities.Concrete;

namespace BasakWeb.DataAccess.Concrete.EntityFramework
{
    public class EfProductDAL : EfEntityRepositoryBase<Product, BasakWebContext>, IProductDAL
    //IProductDAL üzerinden business iletişim kuracak ve EfEntityRepositoryBase methodlarını kullanacak alternatifli olabileceği için ef bilmemne dedik
    {
        BasakWebContext db = new BasakWebContext();
        public void SatildiKaldir(int orderid)
        {
            List<Product> products = db.OrderDetails.Where(z => z.OrderId == orderid).Select(x => x.Product).ToList();
            foreach (Product item in products)
            {
                item.Sold = false;
                var updatedEntity2 = db.Entry(item);
                updatedEntity2.State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
