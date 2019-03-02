using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace hikayeyaziyoruz.Data
{
    public class Uye
    {
        public int UyeId { get; set; }


        [Required(ErrorMessage = "Lütfen adınızı giriniz.")]

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Adınızı 3-50 karakter arasında girebilirsiniz.")]
        public string Ad { get; set; }
        [Required(ErrorMessage = "Lütfen kullanıcı adını giriniz.")]

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Kullanıcı 3-50 karakter arasında girebilirsiniz.")]
        public string kullaniciAdi { get; set; }
        [Required]
       
        [DataType(DataType.Password)]
        
        public string sifre { get; set; }


        [Required(ErrorMessage = "Lütfen soyadınızı giriniz.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Soyadınızı 3-50 karakter arasında girebilirsiniz.")]
        public string Soyad { get; set; }

        [Required(ErrorMessage = "Lütfen e-posta adresinizi giriniz.")]

        [DataType(DataType.EmailAddress, ErrorMessage = "Lütfen e-posta adresinizi geçerli bir formatta giriniz.")]
        public string EPosta { get; set; }



       


        
        public virtual List<Yorum> Yorums { get; set; }

        //Bir üyenin eklediği, birden çok makale olabilir.
        public virtual List<anametin> anametins { get; set; }

        public virtual List<metin> metins { get; set; }

    }
}