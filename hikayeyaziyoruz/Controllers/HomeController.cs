using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using hikayeyaziyoruz.Data;

namespace hikayeyaziyoruz.Controllers
{
    

    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult yorumekle(int anametinID)
        {
            hikayeyaziyoruzContext db = new hikayeyaziyoruzContext();

            
            Yorum mt = new Yorum();
            

            mt.anametin = (from i in db.anametins where i.anametinId == anametinID select i).SingleOrDefault();
            return PartialView(mt);
        }
        public ActionResult hikayeler()
        {
           
            hikayeyaziyoruzContext db = new hikayeyaziyoruzContext();

           
            List<anametin> hepsi = db.anametins.ToList();

            
            return View(hepsi);
        }
        public ActionResult populerHikayeler()
        {
            
            hikayeyaziyoruzContext db = new hikayeyaziyoruzContext();

            List<anametin> hikayeliste = db.anametins.Take(5).ToList();

           
            return PartialView(hikayeliste);
        }

        public ActionResult uyegiris()
        {
        
            {
                
            }
            return View();
        }

        [HttpPost]
        public string uyegiris(Uye Model)
        {
            using (hikayeyaziyoruzContext db = new hikayeyaziyoruzContext())
            {
               
                Uye uye = (from i in db.Uyes where i.sifre == Model.sifre && i.kullaniciAdi == Model.kullaniciAdi select i).SingleOrDefault();



                if(uye!=null){
                    Session["ad"] = uye.Ad;
                    Session["soyad"] = uye.Soyad;
                    Session["EPosta"] = uye.EPosta;
                    Session["kullanıcıAdi"] = uye.kullaniciAdi;
                    Session["id"] = uye.UyeId;
                    return "Sisteme, başarıyla giriş yaptınız.<script type='text/javascript'>setTimeout(function(){window.location='/'},1000);</script>";
                }
                else
                {
                    
                    return "Kullanıcı adı veya şifre hatalı.<script type='text/javascript'>setTimeout(function(){window.location='/Home/uyegiris'},1000);</script>";
                }

                
                
            }
        }

        public ActionResult uyeol()
        {
            return View();
        }
        
        public ActionResult profil()
        {

            return View();
        }
     
        public RedirectToRouteResult cikis()
        {
            Session["kullanıcıAdi"] = null;
            Session["ad"] = null;
            Session["soyad"] = null;
            Session["EPosta"] = null;
            Session["id"] = null;

            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public string uyeol(Uye Model)
        {

            Uye uye = new Uye();
            uye.Ad = Model.Ad;
            uye.Soyad = Model.Soyad;
            uye.EPosta = Model.EPosta;
            uye.kullaniciAdi = Model.kullaniciAdi;
            uye.sifre = Model.sifre;
            
            using (hikayeyaziyoruzContext db = new hikayeyaziyoruzContext())
            {
                if (null == (from i in db.Uyes where i.kullaniciAdi == Model.kullaniciAdi select i).SingleOrDefault())
                {
                    db.Uyes.Add(uye);
                    db.SaveChanges();
                    Session["ad"] = uye.Ad;
                    Session["soyad"] = uye.Soyad;
                    Session["EPosta"] = uye.EPosta;
                    Session["kullanıcıAdi"] = uye.kullaniciAdi;
                    Session["id"] = uye.UyeId;
                    return "Başarılı bir şekilde üye oldunuz.Anasayfaya yönlendiriliyorsunuz.<script type='text/javascript'>setTimeout(function(){window.location='/Home/Index'},1000);</script>";
                }
                else
                {
                    return "Böyle bir kullanıcı adı zaten var.<script type='text/javascript'>setTimeout(function(){window.location='/Home/uyeol'},1000);</script>";
                }
            }
        }
        public RedirectToRouteResult hikayesil(int anametinID)
        {
            using (hikayeyaziyoruzContext db = new hikayeyaziyoruzContext())
            {
                db.anametins.Remove(db.anametins.First(i => i.anametinId == anametinID));
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
        }
        public RedirectToRouteResult metinsil(int metinID)
        {
            using (hikayeyaziyoruzContext db = new hikayeyaziyoruzContext())
            {
                metin mt = (from i in db.metins where i.metinId == metinID select i).SingleOrDefault();
                int c = mt.anametin.anametinId;
                
                db.metins.Remove(db.metins.First(i => i.metinId == metinID));
                db.SaveChanges();
                return RedirectToAction("butunhikaye", "Home", new { anametinID = c });
            }
        }

        public ActionResult uyebilgi(int uyeID)
        {
            hikayeyaziyoruzContext db = new hikayeyaziyoruzContext();

           
            Uye uye = (from i in db.Uyes where i.UyeId == uyeID select i).SingleOrDefault();
            
            uye.anametins= (from i in db.anametins where i.Uye.UyeId == uyeID select i).ToList();
            return View(uye);

        }
        public RedirectToRouteResult yorumsil(int metinID)
        {
            using (hikayeyaziyoruzContext db = new hikayeyaziyoruzContext())
            {
                Yorum mt = (from i in db.Yorums where i.YorumId == metinID select i).SingleOrDefault();
                int c = mt.anametin.anametinId;

                db.Yorums.Remove(db.Yorums.First(i => i.YorumId == metinID));
                db.SaveChanges();
                return RedirectToAction("butunhikaye", "Home", new { anametinID = c });
            }
        }
        public ActionResult butunhikaye(int anametinID)
        {
            hikayeyaziyoruzContext db = new hikayeyaziyoruzContext();

            
            anametin anaMetin = (from i in db.anametins where i.anametinId == anametinID select i).SingleOrDefault();
            return View(anaMetin);
        }
        public ActionResult ekle()
        {
            return View();
        }
        public ActionResult metinekle(int anametinIDd)
        {
            hikayeyaziyoruzContext db = new hikayeyaziyoruzContext();

            
          metin  mt = new metin();
            
            
            mt.anametin= (from i in db.anametins where i.anametinId == anametinIDd select i).SingleOrDefault();
            return PartialView(mt);
        }
       
        [HttpPost]
        
        public RedirectToRouteResult metinekle(string ice,int ide)
        {

            metin metin1 = new metin();
            metin1.Metin = ice;
           


            using (hikayeyaziyoruzContext db = new hikayeyaziyoruzContext())
            {
                int a = Convert.ToInt32(Session["id"]);
                Uye uye = (from i in db.Uyes where i.UyeId == a select i).SingleOrDefault();

                anametin ametin = (from i in db.anametins where i.anametinId == ide select i).SingleOrDefault();
                metin1.Uye = uye;
                metin1.anametin = ametin;
                db.metins.Add(metin1);
                db.SaveChanges();

                return RedirectToAction("butunhikaye", "Home", new { anametinID = metin1.anametin.anametinId });
            }


        }
        [HttpPost]

        public RedirectToRouteResult yorumekle(string ta, int id)
        {

            Yorum yorum1 = new Yorum();
            yorum1.Icerik = ta;



            using (hikayeyaziyoruzContext db = new hikayeyaziyoruzContext())
            {
                int a = Convert.ToInt32(Session["id"]);
                Uye uye = (from i in db.Uyes where i.UyeId == a select i).SingleOrDefault();

                anametin ametin = (from i in db.anametins where i.anametinId == id select i).SingleOrDefault();
                yorum1.Uye = uye;
                yorum1.anametin = ametin;
                db.Yorums.Add(yorum1);
                db.SaveChanges();

                return RedirectToAction("butunhikaye", "Home", new { anametinID = yorum1.anametin.anametinId });
            }


        }
        [HttpPost]
        public RedirectToRouteResult ekle(anametin Model)
        {
            anametin ametin = new anametin();
            ametin.anaFikir = Model.anaFikir;
            ametin.anaMetin = Model.anaMetin;
            ametin.hikayeAdi = Model.hikayeAdi;
            ametin.hikayeTuru = Model.hikayeTuru;
            ametin.Tarih = DateTime.Now;
           
            
            using (hikayeyaziyoruzContext db = new hikayeyaziyoruzContext()) 
            {
                int a = Convert.ToInt32(Session["id"]);
                Uye uye = (from i in db.Uyes where i.UyeId == a select i).SingleOrDefault();
                ametin.Uye = uye;
                db.anametins.Add(ametin);
                db.SaveChanges();

                return RedirectToAction("butunhikaye", "Home", new { anametinID = ametin.anametinId });
            }

           
        }
        public ActionResult altmetinler(int anametinID)
        {
            
            hikayeyaziyoruzContext db = new hikayeyaziyoruzContext();

            
            List<metin> Metin1 = (from i in db.metins where i.anametin.anametinId == anametinID select i).ToList();
           
            return PartialView(Metin1);
        }
        public ActionResult yorumlar(int anametinID)
        {
           
            hikayeyaziyoruzContext db = new hikayeyaziyoruzContext();

            List<Yorum> Yorum1 = (from i in db.Yorums where i.anametin.anametinId == anametinID select i).ToList();

            return PartialView(Yorum1);
        }


        public ActionResult nedir()
        {


            return View();

        }
    }
}