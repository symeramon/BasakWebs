using BasakWeb.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BasakWeb.Helpers
{
    public class SharedSelectListMethods
    {
        
        public SelectList GetCollectionList()
        {
            BasakWebContext db = new BasakWebContext();
            var Collections = db.Collections.Where(z=> z.Silindi == false).ToList();

            return new SelectList(Collections, "Id", "CollectionName");
        }
    }
}