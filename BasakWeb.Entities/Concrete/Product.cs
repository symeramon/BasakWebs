using BasakWeb.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BasakWeb.Entities.Concrete
{
    public class Product : IEntity
    {
     
        [Key]
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        public decimal? UnitPriceOld { get; set; }
        [Required]
        public string Picture { get; set; }
        public string ProductDescription { get; set; }
        public int Discount { get; set; }
        [Required]
        public int Collection_Id { get; set; }

        [ForeignKey("Collection_Id")]
        public virtual Collection Collection { get; set; }
        [Required]
        public short UnitsInStock
        {
            get; set;
        }
        [Required]
        public DateTime DateAdded { get; set; }
        [Required]
        public bool Sold { get; set; }

        public bool Silindi { get; set; }
    }
}