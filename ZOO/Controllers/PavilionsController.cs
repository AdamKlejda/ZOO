using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ZOO.Models;

namespace ZOO.Controllers
{   
    public class PavilonViewModel
    {
        public Pavilions pavilion { get; set; }
        public List<Animals> animals { get; set; }
        public List<Cleanings> cleanings { get; set; }

    }
    public class PavilionsController : Controller
    {
        private ZOOEntities db = new ZOOEntities();

        // GET: Pavilions
        public ActionResult Index()
        {
            return View(db.Pavilions.ToList());
        }

        // GET: Pavilions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pavilions pavilions = db.Pavilions.Find(id);
            if (pavilions == null)
            {
                return HttpNotFound();
            }
            //Animals animals = db.Animals.find()
            var animals = from a in db.Animals
                          join ag in db.AnimalGroups on a.AnimalGroupId equals ag.AnimalGroupId
                          join p in db.Pavilions on ag.PavilionId equals p.PavilionId
                          where p.PavilionId == id
                          select a;
            var cleanings = from s in db.Cleanings
                            where s.PavilionId == id
                            select s;

            PavilonViewModel data = new PavilonViewModel();
            if(animals != null)
            {
                ViewBag.Exception = null;
                string msg = null;
                try
                {
                    List<Animals> Tanimals = new List<Animals>();
                    foreach (var animal in animals)
                    {

                        Tanimals.Add(animal);
                    }
                    data.animals = Tanimals;

                }
                catch (Exception e) {
                    msg = e.InnerException.InnerException.Message;
                    ViewBag.Exception = msg;
                }
            }
            data.pavilion = pavilions;

            if (cleanings != null)
            {
                ViewBag.Exception = null;
                string msg = null;
                try
                {
                    List<Cleanings> Tcleanings = new List<Cleanings>();
                    foreach (var cleaning in cleanings)
                    {

                        Tcleanings.Add(cleaning);
                    }
                    data.cleanings = Tcleanings;

                }
                catch (Exception e)
                {
                    msg = e.InnerException.InnerException.Message;
                    ViewBag.Exception = msg;
                }
            }
            data.pavilion = pavilions;

            return View(data);
        }

        // GET: Pavilions/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pavilions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PavilionId,Surface,Name")] Pavilions pavilions)
        {
            if (ModelState.IsValid)
            {
                db.Pavilions.Add(pavilions);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(pavilions);
        }

        // GET: Pavilions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pavilions pavilions = db.Pavilions.Find(id);
            if (pavilions == null)
            {
                return HttpNotFound();
            }
            return View(pavilions);
        }

        // POST: Pavilions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PavilionId,Surface,Name")] Pavilions pavilions)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pavilions).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pavilions);
        }

        // GET: Pavilions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pavilions pavilions = db.Pavilions.Find(id);
            if (pavilions == null)
            {
                return HttpNotFound();
            }
            return View(pavilions);
        }

        // POST: Pavilions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pavilions pavilions = db.Pavilions.Find(id);
            db.Pavilions.Remove(pavilions);
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
