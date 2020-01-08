using BasakWeb.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BasakWeb.Models
{
    public class GirisPageVM
    {
        public List<Collection> Collections { get; set; }
        public IEnumerable<Product> LatestProducts { get; internal set; }
        public IOrderedEnumerable<Product> ProductList { get; internal set; }
    }
}