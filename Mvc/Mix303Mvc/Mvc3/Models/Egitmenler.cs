using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc3.Models
{
    public class Egitmenler
    {
        public int Id { get; set; }
        public string  Adi { get; set; }
        public string Soyadi { get; set; }
        public string EgitmenNo { get; set; }
        public string Tc { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public int?  BransId  { get; set; } //BransId Null gelebilir.
        public virtual Brans Brans { get; set; } //Brans ile  bağlantı için kullandık.BransId nin altına yazdık.Çünkü FORINKEY için altına yazmak gereklidir.


    }
}