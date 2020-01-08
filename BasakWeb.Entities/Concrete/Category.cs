using BasakWeb.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BasakWeb.Entities.Concrete
{
    public class Category: IEntity
    {
    
        [Key]
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public string CategoryName { get; set; }
        public string Picture { get; set; }
        public string CategoryDescription { get; set; }
    }
}