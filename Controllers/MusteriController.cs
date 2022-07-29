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
    }
}