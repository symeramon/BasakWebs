using BasakWeb.Entities.Concrete;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BasakWeb.Models
{
    public class ProductVM
    {
        [Display(Name = "Ürün Adı")]
        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        public string ProductName { get; set; }
        [Display(Name = "Ürün Fiyatı")]
        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        public decimal UnitPrice { get; set; }
        [Display(Name = "Ürün Eski Fiyatı")]
        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        public decimal? UnitPriceOld { get; set; }
        public IPagedList<Product> ProductList { get; set; }
        public string Picture { get; set; }
        [Display(Name = "Ürün Açıklama")]
        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        public string ProductDescription { get; set; }
        [Display(Name = "İndirim")]
        public int Discount { get; set; }

        [Display(Name = "Satıldı")]
        public bool Sold { get; set; }
    }
}