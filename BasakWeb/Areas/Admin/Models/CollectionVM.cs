using BasakWeb.Entities.Concrete;
using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BasakWeb.Areas.Admin.Models
{
    public class CollectionVM
    {
        [Display(Name = "Koleksiyon Adı")]
        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        public string CollectionName { get; set; }
        [Display(Name = "Koleksiyon Açıklaması")]
        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        public string Description { get; set; }
        [Display(Name = "Koleksiyon Resmi")]
        public string Picture { get; set; }
        public IPagedList<Collection> CollectionList { get; set; }
        public int ID { get; set; }

    }
}