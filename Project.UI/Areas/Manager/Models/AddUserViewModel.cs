using Microsoft.AspNetCore.Http;
using Project.ENTITIES.DTOs;
using Project.ENTITIES.Enums;
using Project.ENTITIES.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project.UI.Areas.Manager.Models
{
    public class AddUserViewModel
    {
        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "{0} gerekli!")]
        public string UserName { get; set; }
        [Display(Name = "İsim")]
        [Required(ErrorMessage = "{0} gerekli!")]
        public string FirstName { get; set; }
        [Display(Name = "Soyisim")]
        [Required(ErrorMessage = "{0} gerekli!")]
        public string LastName { get; set; }
        [Display(Name = "Doğum Tarihi")]
        public DateTime BirthDate { get; set; }
        [DisplayName("Fotoğraf")]
        
        public string Picture { get; set; }
        [Display(Name = "Cinsiyet")]
        [Required(ErrorMessage = "{0} gerekli!")]
        public Gender Gender { get; set; }
        [Display(Name = "Mail Adresi")]
        [Required(ErrorMessage = "{0} gerekli!")]
        [EmailAddress(ErrorMessage = "Lütfen {0}'ni doğru formatta giriniz!")]
        public string Email { get; set; }
        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "{0} gerekli!")]
        [MinLength(4, ErrorMessage = "{0}, en az {1} karakter olmalıdır!")]
        public string Password { get; set; }
        [Display(Name = "Telefon Numarası")]
        [Required(ErrorMessage = "{0} gerekli!")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Kullanıcı Rolleri")]
        [Required(ErrorMessage = "{0} gerekli!")]
        public List<AssignRoleDto> UserRoles { get; set; } = new List<AssignRoleDto>();

    }
}
