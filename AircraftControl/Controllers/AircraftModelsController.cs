using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using AircraftControl.Models;
using PagedList;



namespace AircraftControl.Controllers
{
    public class AircraftModelsController : Controller
    {
        private AircraftControlEntities db = new AircraftControlEntities();

        // GET: AircraftModels
        public ActionResult Index(String procurarPor, string criterio, int? pagina, string ordenarPor)
        {
            
            //Ordenar por Code/Alternative Code - filtro
            ViewBag.OrdenarPorCode = string.IsNullOrEmpty(ordenarPor) ? "Code desc" : "";
            ViewBag.OrdenarPorAlternativeCode = string.IsNullOrEmpty(ordenarPor) || ordenarPor == "ALTERNATIVE_CODE"  ? "Alternative Code desc" : "";

            var aircraftmodel = db.tblAircraftModels.AsQueryable();

            if (procurarPor == "CODE")
            {
                aircraftmodel = aircraftmodel.Where(x => x.CODE.StartsWith(criterio) || criterio == null || criterio == "");
                //return View(db.tblAircraftModels.Where(x => x.CODE.StartsWith(criterio) || criterio == null || criterio == "").ToList().ToPagedList(pagina ?? 1, 5));
            }
            else
            {
                aircraftmodel = aircraftmodel.Where(x => x.ALTERNATIVE_CODE.StartsWith(criterio) || criterio == null);
                //return View(db.tblAircraftModels.Where(x => x.ALTERNATIVE_CODE.StartsWith(criterio) || criterio == null).ToList().ToPagedList(pagina ?? 1, 5));
            }

            //verificar o parametro
            switch (ordenarPor)
            {
                case "Code desc" :
                    aircraftmodel = aircraftmodel.OrderBy(x => x.CODE);
                    break;

                case "Alternative Code desc": 
                    aircraftmodel = aircraftmodel.OrderBy(x => x.ALTERNATIVE_CODE);
                    break;

                case "ALTERNATIVE_CODE":
                    aircraftmodel = aircraftmodel.OrderBy(x => x.ALTERNATIVE_CODE);
                    break;

                default:
                    aircraftmodel = aircraftmodel.OrderBy(x => x.ALTERNATIVE_CODE);
                    break;
            }

            return View(aircraftmodel.ToPagedList(pagina ?? 1,5));

        }

        // GET: AircraftModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAircraftModel tblAircraftModel = db.tblAircraftModels.Find(id);
            if (tblAircraftModel == null)
            {
                return HttpNotFound();
            }
            return View(tblAircraftModel);
        }

        // GET: AircraftModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AircraftModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_AIRCRAFTMODEL,CODE,ALTERNATIVE_CODE,MAX_DEPARTURE_WEIGHT,MAX_LANDING_WEIGHT")] tblAircraftModel tblAircraftModel)
        {
            if (ModelState.IsValid)
            {
                db.tblAircraftModels.Add(tblAircraftModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblAircraftModel);
        }

        // GET: AircraftModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAircraftModel tblAircraftModel = db.tblAircraftModels.Find(id);
            if (tblAircraftModel == null)
            {
                return HttpNotFound();
            }
            return View(tblAircraftModel);
        }

        // POST: AircraftModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_AIRCRAFTMODEL,CODE,ALTERNATIVE_CODE,MAX_DEPARTURE_WEIGHT,MAX_LANDING_WEIGHT")] tblAircraftModel tblAircraftModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblAircraftModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblAircraftModel);
        }

        // GET: AircraftModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAircraftModel tblAircraftModel = db.tblAircraftModels.Find(id);
            if (tblAircraftModel == null)
            {
                return HttpNotFound();
            }
            return View(tblAircraftModel);
        }

        // POST: AircraftModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblAircraftModel tblAircraftModel = db.tblAircraftModels.Find(id);
            db.tblAircraftModels.Remove(tblAircraftModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
