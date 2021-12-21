using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.UI.Areas.Manager.Models
{
    public class UpdateSupplierViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Tedarikçi Adı")]
        [Required(ErrorMessage = "{0} gerekli!")]
        [MaxLength(40, ErrorMessage = "{0} en fazla {1} karakter olabilir!")]
        public string CompanyName { get; set; }
        [Display(Name = "İletişim Kişisi")]
        [MaxLength(30, ErrorMessage = "{0} en fazla {1} karakter olabilir!")]
        public string ContactName { get; set; }
        [Display(Name = "İletişim Başlığı")]
        [MaxLength(30, ErrorMessage = "{0} en fazla {1} karakter olabilir!")]
        public string ContactTitle { get; set; }
        [Display(Name = "Adres")]
        [MaxLength(60, ErrorMessage = "{0} en fazla {1} karakter olabilir!")]
        public string Address { get; set; }
        [Display(Name = "Şehir")]
        [MaxLength(15, ErrorMessage = "{0} en fazla {1} karakter olabilir!")]
        public string City { get; set; }
        [Display(Name = "Posta Kodu")]
        [Required(ErrorMessage = "{0} gerekli!")]
        [MaxLength(15, ErrorMessage = "{0} en fazla {1} karakter olabilir!")]
        public string PostalCode { get; set; }
        [Display(Name = "Ülke")]
        [MaxLength(15, ErrorMessage = "{0} en fazla {1} karakter olabilir!")]
        public string Country { get; set; }
        [Display(Name = "Telefon Numarası")]
        [Required(ErrorMessage = "{0} gerekli!")]
        [MaxLength(24, ErrorMessage = "{0} en fazla {1} karakter olabilir!")]
        public string Phone { get; set; }
    }
}
