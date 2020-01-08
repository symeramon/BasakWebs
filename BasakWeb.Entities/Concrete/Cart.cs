using BasakWeb.Core.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BasakWeb.Entities.Concrete
{
    public class Cart:IEntity
    {
        [Key]
        public int ID { get; set; }
        public Cart()
        {
            CartLines = new List<CartLine>();
        }
        public List<CartLine> CartLines { get; set; }
        public decimal Total
        {
            get { return CartLines.Sum(c => c.Product.UnitPrice * c.Quantity); }
        }
    }
}