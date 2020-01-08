using BasakWeb.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace BasakWeb.Entities.Concrete
{
    public class Order:IEntity
    {
        [Key]
        [Required]
        public int OrderId { get; set; }

        public string CustomerID { get; set; }

        [ForeignKey("CustomerID")]
        public virtual ApplicationUser Customer { get; set; }
        [Display(Name = "Sipariş Tarihi")]
        public DateTime OrderDate { get; set; }
       
        public DateTime? RequiredDate { get; set; }
        public DateTime? ShippedDate { get; set; }
        [Display(Name = "Adresi")]
        public string ShipAddress { get; set; }
        public virtual ICollection<OrderDetails> Details { get; set; }
        [Display(Name = "Şehri")]
        public string ShipCity { get; set; }

        public string ShipRegion { get; set; }
        public bool Sozlesme { get; set; }

        public bool Silindi { get; set; }
    }
}