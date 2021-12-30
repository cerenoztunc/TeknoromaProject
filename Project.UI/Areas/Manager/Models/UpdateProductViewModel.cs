using Project.ENTITIES.DTOs;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.UI.Areas.Manager.Models
{
    public class UpdateProductViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Ürün Adı")]
        [Required(ErrorMessage = "{0} gerekli!")]
        [MaxLength(40, ErrorMessage = "{0} en fazla {1} karakter olabilir!")]
        public string ProductName { get; set; }
        [Display(Name = "Ürün Fiyatı")]
        [Required(ErrorMessage = "{0} gerekli!")]
        public decimal UnitPrice { get; set; }
        [Display(Name = "Stok")]
        [Required(ErrorMessage = "{0} gerekli!")]
        public short UnitsInStock { get; set; }
        [Display(Name = "Ürün Satışta Mı?")]
        [Required(ErrorMessage = "{0} gerekli!")]
        public bool Discontinued { get; set; } //ürün hala satılıyor mu
        [Display(Name = "Birim Başı Miktar")]
        [Required(ErrorMessage = "{0} gerekli!")]
        public string QuantityPerUnit { get; set; } //birim başına miktar
        [Display(Name = "Sipariş Üzerine Birimler")]
        [Required(ErrorMessage = "{0} gerekli!")]
        public short UnitsOnOrder { get; set; } //sipariş üzerine birimler
        [Display(Name = "Kategori")]
        [Required(ErrorMessage = "{0} gerekli!")]
        public int CategoryId { get; set; }
        public List<Category> Categories { get; set; } = new List<Category>();
        
        [Display(Name = "Tedarikçi")]
        [Required(ErrorMessage = "{0} gerekli!")]
        public int SupplierId { get; set; }
        public List<Supplier> Suppliers { get; set; } = new List<Supplier>();
    }
}
