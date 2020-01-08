using BasakWeb.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BasakWeb.Entities.Concrete
{
    public class CartLine: IEntity
    {
        [Key]
        public int ID { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}