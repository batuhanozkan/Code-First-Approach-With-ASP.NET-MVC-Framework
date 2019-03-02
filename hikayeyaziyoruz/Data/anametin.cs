using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace hikayeyaziyoruz.Data
{
    public class anametin
    {
        public int anametinId { get; set; }

        [Required(ErrorMessage = "Lütfen hikayenin adını giriniz.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Makale başlığı 3-50 karakter arasında olmalıdır.")]
        public string hikayeAdi { get; set; }

        [Required(ErrorMessage = "Lütfen metni giriniz.")]
        
        [DataType(DataType.Html, ErrorMessage = "Lütfen makale içeriğini html formatında giriniz.")]
        public string anaMetin { get; set; }
        [Required(ErrorMessage = "Lütfen hikayenin türünü giriniz.")]
        public string hikayeTuru { get; set; }


        [Required(ErrorMessage = "Lütfen hikayenin ana fikrini giriniz.")]
        public string anaFikir { get; set; }
        public DateTime Tarih { get; set; }

        public virtual Uye Uye { get; set; }


        
        public virtual List<Yorum> Yorums { get; set; }

        public virtual List<metin> metins { get; set; }

    }
}