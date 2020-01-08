using BasakWeb.Entities.Concrete;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BasakWeb.Areas.Admin.Models
{
    public class OrderVM
    {

        [Display(Name = "Sipariş No")]
        public int OrderId { get; set; }

        [Display(Name = "Sipariş Tarihi")]
        public DateTime OrderDate { get; set; }
        [Display(Name = "Gönderim Adresi")]
        public string ShipAddress { get; set; }
        [Display(Name = "Gönderim Şehri")]
        public string ShipCity { get; set; }
        public IPagedList<Order> OrderList { get; set; }


        public int? Kullanici_Id { get; set; }
        public string KullaniciAdi { get; set; }
    }
}