using BasakWeb.Core.DataAccess.EntityFramework;
using BasakWeb.DataAccess.Abstract;
using BasakWeb.Entities.Concrete;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasakWeb.DataAccess.Concrete.EntityFramework
{
    public class EFCollectionDAL : EfEntityRepositoryBase<Collection, BasakWebContext>, ICollectionDAL
    {
        BasakWebContext db = new BasakWebContext();
        public List<Collection> GetCollectionListwithProducts()
        {
        
            var result =
   (from collections in db.Collections where collections.Silindi == false

    select new
    {
        collections,
        products = from prd in collections.Products
                 where prd.Silindi == false
                 select prd
    }).AsEnumerable()
      .Select(a => a.collections);


            return result.ToList();
        }
    }
}
