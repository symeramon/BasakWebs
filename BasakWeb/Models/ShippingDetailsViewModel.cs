using BasakWeb.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BasakWeb.Models
{
    public class ShippingDetailsViewModel
    {
        [Display(Name = "İsim")]
        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        public string FirstName { get; set; }

        [Display(Name = "Soy İsim")]
        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Şehir")]
        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        public string City { get; set; }

        [Display(Name = "Adres")]
        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        [Range(15, 75)]
        public int Age { get; set; }
    }
}