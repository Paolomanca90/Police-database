using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using U4_W4_BENCHMARK.Models;

namespace U4_W4_BENCHMARK.Controllers
{
    public class VerbaleController : Controller
    {
        public List<SelectListItem> AnagraficaTrasgressori
        {
            get
            {
                List<SelectListItem> list = new List<SelectListItem>();
                List<Trasgressore> lista = new List<Trasgressore>();
                lista = DB.getTrasgressori();
                foreach(Trasgressore t in lista)
                {
                    SelectListItem item = new SelectListItem { Text = $"{t.Cognome}, {t.Nome}", Value = $"{t.IdTrasgressore}" };
                    list.Add(item);
                }
                return list;
            }
        }
        
        public List<SelectListItem> ListaViolazioni
        {
            get
            {
                List<SelectListItem> list = new List<SelectListItem>();
                List<Violazione> lista = new List<Violazione>();
                lista = DB.getViolazioni();
                foreach(Violazione v in lista)
                {
                    SelectListItem item = new SelectListItem { Text = $"{v.Descrizione}", Value = $"{v.IdViolazione}" };
                    list.Add(item);
                }
                return list;
            }
        }

        // GET: Verbale
        public ActionResult Index()
        {
            List<Verbale> lista = new List<Verbale>();
            lista = DB.getVerbali();
            return View(lista);
        }

        public ActionResult Create()
        {
            ViewBag.Violazioni = ListaViolazioni;
            ViewBag.ListaAnagrafica = AnagraficaTrasgressori;
            return View();
        }

        [HttpPost]
        public ActionResult Create(Verbale v)
        {
            if (ModelState.IsValid)
            {
                DB.insertVerbale(v);
                TempData["OK"] = "Verbale aggiunto con successo";
                return RedirectToAction("Index", "Verbale");
            }
            else
            {
                ViewBag.Messaggio = "Campi non inseriti correttamente";
                ViewBag.ListaAnagrafica = AnagraficaTrasgressori;
                return View();
            }
        }

        public ActionResult Registro()
        {
            List<VerbaliTotali> lista = new List<VerbaliTotali>();
            lista = DB.verbaliPerTrasgressore();
            ViewBag.VerbaliTrasgressore = lista;

            List<PuntiTotali> punti = new List<PuntiTotali>();
            punti = DB.puntiPerTrasgressore();
            ViewBag.PuntiTrasgressore = punti;

            List<Over10> over10 = new List<Over10>();
            over10 = DB.overDieciPerTrasgressore();
            ViewBag.OverPunti = over10;

            List<MaxiMulte> maxi = new List<MaxiMulte>();
            maxi = DB.MaxiMulte();
            ViewBag.MaxiMulte = maxi;

            return View();
        }
    }
}