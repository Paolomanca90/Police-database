using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using U4_W4_BENCHMARK.Models;

namespace U4_W4_BENCHMARK.Controllers
{
    public class TrasgressoreController : Controller
    {
        // GET: Trasgressore
        public ActionResult Index()
        {
            List<Trasgressore> lista = new List<Trasgressore>();
            lista = DB.getTrasgressori();
            return View(lista);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Trasgressore t)
        {
            if (ModelState.IsValid)
            {
                DB.insertAnagrafica(t);
                TempData["OK"] = "Anagrafica aggiunta con successo";
                return RedirectToAction("Index","Trasgressore");
            }
            else
            {
                ViewBag.Messaggio = "Campi non inseriti correttamente";
                return View();
            }
        }
    }
}