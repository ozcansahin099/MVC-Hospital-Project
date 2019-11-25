using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToDoApp303.Models
{
    public class Customer:BaseEntity
    {

        [StringLength(200)]
        [Required(ErrorMessage = "Bu alanı doldurmak zorunludur.")]
        [DisplayName("Ad")]
        public string Name { get; set; }

        [StringLength(200)]
        [DataType(DataType.EmailAddress, ErrorMessage = "xxx@yyy.com formatında olmalıdır.")]
        [DisplayName("E-Posta")]
        public string Email { get; set; }

        [StringLength(20), DisplayName("Telefon")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Geçerli bir telefon numarasaı giriniz.")]
        public string Phone { get; set; }

        [StringLength(20), DisplayName("Faks")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "Geçerli bir fax numarasaı giriniz.")]
        public string Fax { get; set; }

        [StringLength(100), DisplayName("Web Sayfası")]
        [DataType(DataType.Url, ErrorMessage = "Geçerli bir url giriniz.")]
        public string WebPage { get; set; }

        [ DisplayName("Adres")]
        public string Address { get; set; }
    }
}