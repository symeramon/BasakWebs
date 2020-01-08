using BasakWeb.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasakWeb.Entities.Concrete
{
    public class Collection : IEntity
    {
        [Key]
        public int ID { get; set; }
        public string CollectionName { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Product> Products { get; set; }
        public string Picture { get; set; }
        public bool Silindi { get; set; }
    }
}
