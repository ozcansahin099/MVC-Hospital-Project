using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ToDoApp303.Models
{
    public class Category:BaseEntity
    {
        [StringLength(200)]
        [Required(ErrorMessage ="Kategori adı girilmesi zorunludur.")]
        [DisplayName("Kategori Adı")]
        public string Name { get; set; }
    }
}