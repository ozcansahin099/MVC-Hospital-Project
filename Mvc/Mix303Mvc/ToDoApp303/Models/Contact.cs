using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToDoApp303.Models
{
    public class Contact:BaseEntity
    {
        [StringLength(200)]
        [Required(ErrorMessage ="Bu alanı doldurmak zorunludur.")]
        [DisplayName("Ad")]
        public string FirstName { get; set; }

        [StringLength(200)]
        [Required(ErrorMessage = "Bu alanı doldurmak zorunludur.")]
        [DisplayName("Soyad")]
        public string LastName { get; set; }

        [StringLength(200)]
        [DataType(DataType.EmailAddress,ErrorMessage ="xxx@yyy.com formatında olmalıdır.")]
        [DisplayName("E-Posta")]
        public string Email { get; set; }

        [StringLength(20), DisplayName("Telefon")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Geçerli bir telefon numarasaı giriniz.")]
        public string Phone { get; set; }

    }
}