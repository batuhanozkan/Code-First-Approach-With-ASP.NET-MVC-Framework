using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace hikayeyaziyoruz.Data
{

    public class metin
    {
        
        public int metinId { get; set; }
        [Required(ErrorMessage = "Lütfen metni giriniz.")]
        
        [DataType(DataType.Html, ErrorMessage = "Lütfen makale içeriğini html formatında giriniz.")]
        public string Metin { get; set; }
        public virtual Uye Uye { get; set; }
        public virtual anametin anametin { get; set; }

       
        
    }
}