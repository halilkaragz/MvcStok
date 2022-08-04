using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;

namespace MvcStok.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        dbMvcStokEntities db = new dbMvcStokEntities();
        public ActionResult Index()
        {
            var degerler = db.Urunler.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniUrunEkle()
        {
            List<SelectListItem> degerler = (from i in db.Kategoriler.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = i.Ad,
                                                 Value = i.Id.ToString()
                                             }).ToList();
            ViewBag.dgr = degerler;
            return View();
        }

        [HttpPost]
        public ActionResult YeniUrunEkle(Urunler p1)
        {   //model i oluşturmadan önce sql tarafında diagram oluşturmadığım için ürün eklerken kategori doropdown'ı
            //istediğim gibi çalışmıyor
            //var ktg = db.Kategoriler.Where(k => k.Id == p1.Kategoriler.Id).FirstOrDefault();
            //p1.Kategoriler = ktg;
           
            db.Urunler.Add(p1);
            db.SaveChanges();
            // return RedirectToAction("Index");
            return View();
            
        }


    }
}