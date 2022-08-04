using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        dbMvcStokEntities db = new dbMvcStokEntities();
        public ActionResult Index()
        {
            var musteriler = db.Musteriler.ToList();
            return View(musteriler);
        }

        [HttpGet]
        public ActionResult YeniMusteri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMusteri(Musteriler musteri)
        {
            db.Musteriler.Add(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SIL(int Id)
        {
            var musteri = db.Musteriler.Find(Id);
            db.Musteriler.Remove(musteri);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriGetir(int Id)
        {
            var mus = db.Musteriler.Find(Id);
            return View("MusteriGetir", mus);
        }
        public ActionResult Guncelle(Musteriler p1)
        {
            var musteri = db.Musteriler.Find(p1.Id);
            musteri.Ad = p1.Ad;
            musteri.Soyad = p1.Soyad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}