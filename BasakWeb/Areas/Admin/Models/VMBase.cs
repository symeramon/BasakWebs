using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BasakWeb.Areas.Admin.Models
{
    public class VMBase
    {
        [Key]
        public int id { get; set; }
    }
}