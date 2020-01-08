using BasakWeb.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BasakWeb.ViewModels
{
    public class OrderViewModel
    {
        public OrderViewModel()
        {
            this.Sozlesme = true;
        }
        [Display(Name = "Adres")]
        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        public string Address { get; set; }
        [Display(Name = "Ad")]
        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        public string FirstName { get; set; }
        [Display(Name = "Soyad")]
        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        [Display(Name = "Telefon")]
        [Range(0, int.MaxValue, ErrorMessage = "Lütfen telefon numarası giriniz")]
        public string Phone { get; set; }

        [Display(Name = "Şehir")]
        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        public string ShipCity { get; set; }

        [Required(ErrorMessage = "Bu alan boş geçilemez")]
        [EmailAddress(ErrorMessage = "Yanlış email")]
        public string Email { get; set; }

        [Display(Name = "Kabul Ediyorum")]
        public bool Sozlesme { get; set; }
        public Cart Cart { get; set; }
    }
}