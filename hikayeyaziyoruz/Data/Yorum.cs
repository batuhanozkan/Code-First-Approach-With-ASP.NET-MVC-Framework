using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace hikayeyaziyoruz.Data
{
    public class Yorum
    {
        public int YorumId { get; set; }

        [Required(ErrorMessage = "Lütfen yorumunuzu giriniz.")]
        public string Icerik { get; set; }
        public virtual anametin anametin { get; set; }


        public virtual Uye Uye { get; set; }
    }
}