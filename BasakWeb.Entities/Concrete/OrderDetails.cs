using BasakWeb.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BasakWeb.Entities.Concrete
{
    public class OrderDetails:IEntity
    {
        public bool silindi;

        [Key]
        public int Id { get; set; }

        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }

        public int ProductID { get; set; }

        [ForeignKey("ProductID")]
        [Display(Name = "Ürün")]
        public virtual Product Product { get; set; }
        [Required]
        [Display(Name = "Fiyatı")]
        public int UnitPrice { get; set; }


    }
}