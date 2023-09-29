using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using U4_W4_BENCHMARK.Models;

namespace U4_W4_BENCHMARK.Controllers
{
    public class ViolazioneController : Controller
    {
        // GET: Violazione
        public ActionResult Index()
        {
            List<Violazione> lista = new List<Violazione>();
            lista = DB.getViolazioni();
            return View(lista);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Violazione v)
        {
            if (ModelState.IsValid)
            {
                DB.insertViolazione(v);
                TempData["OK"] = "Violazione aggiunta con successo";
                return RedirectToAction("Index", "Violazione");
            }
            else
            {
                ViewBag.Messaggio = "Campi non inseriti correttamente";
                return View();
            }
        }
    }
}