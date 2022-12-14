using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        dbMvcStokEntities db = new dbMvcStokEntities();
        public ActionResult Index()
        {
            var degerler = db.Kategoriler.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniKategori()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniKategori(Kategoriler p1)
        {
            db.Kategoriler.Add(p1);
            db.SaveChanges();
            return View();
        }

        public ActionResult SIL(int Id)
        {
            var kategori = db.Kategoriler.Find(Id);
            db.Kategoriler.Remove(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KATEGORIGETIR(int Id)
        {
            var kategori = db.Kategoriler.Find(Id);
            return View("KATEGORIGETIR", kategori);
        }

        public ActionResult Guncelle(Kategoriler p1)
        {
            var ktg = db.Kategoriler.Find(p1.Id);
            ktg.Ad = p1.Ad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}