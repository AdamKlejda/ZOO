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
    public class AnimalsGroupModelView
    {
        public AnimalGroups animalGroup { get; set; }
        public List<Feedings> feedings  { get; set; }
        public List<Animals> animals { get; set; }

    }
    public class AnimalGroupsController : Controller
    {
        private ZOOEntities db = new ZOOEntities();

        // GET: AnimalGroups
        public ActionResult Index()
        {
            var animalGroups = db.AnimalGroups.Include(a => a.Pavilions);
            return View(animalGroups.ToList());
        }

        // GET: AnimalGroups/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnimalGroups animalGroups = db.AnimalGroups.Find(id);
            if (animalGroups == null)
            {
                return HttpNotFound();
            }


            AnimalsGroupModelView data = new AnimalsGroupModelView();

            var animals = from a in db.Animals
                          where a.AnimalGroupId == id
                          select a;
            var feedings = from f in db.Feedings
                           where f.AnimalGroupId == id
                           select f;
            try
            {

                if (animals != null)
                {
                    List<Animals> tanimals = new List<Animals>();
                    foreach (Animals animal in animals)
                    {
                        tanimals.Add(animal);
                    }
                    data.animals = tanimals;
                }
            }
            catch (Exception e)
            {

            }
            try
            {
                
                if(feedings != null)
                {
                    List<Feedings> tfeedings = new List<Feedings>();
                    foreach(Feedings feeding in feedings)
                    {
                        tfeedings.Add(feeding);
                    }
                    data.feedings = tfeedings;
                }
            }catch(Exception e)
            {

            }
            data.animalGroup = animalGroups;

            return View(data);
        }

        // GET: AnimalGroups/Create
        public ActionResult Create()
        {
            ViewBag.PavilionId = new SelectList(db.Pavilions, "PavilionId", "Name");
            return View();
        }

        // POST: AnimalGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AnimalGroupId,PavilionId,Name")] AnimalGroups animalGroups)
        {
            if (ModelState.IsValid)
            {
                db.AnimalGroups.Add(animalGroups);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PavilionId = new SelectList(db.Pavilions, "PavilionId", "Name", animalGroups.PavilionId);
            return View(animalGroups);
        }

        // GET: AnimalGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnimalGroups animalGroups = db.AnimalGroups.Find(id);
            if (animalGroups == null)
            {
                return HttpNotFound();
            }
            ViewBag.PavilionId = new SelectList(db.Pavilions, "PavilionId", "Name", animalGroups.PavilionId);
            return View(animalGroups);
        }

        // POST: AnimalGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AnimalGroupId,PavilionId,Name")] AnimalGroups animalGroups)
        {
            if (ModelState.IsValid)
            {
                db.Entry(animalGroups).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PavilionId = new SelectList(db.Pavilions, "PavilionId", "Name", animalGroups.PavilionId);
            return View(animalGroups);
        }

        // GET: AnimalGroups/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AnimalGroups animalGroups = db.AnimalGroups.Find(id);
            if (animalGroups == null)
            {
                return HttpNotFound();
            }
            return View(animalGroups);
        }

        // POST: AnimalGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AnimalGroups animalGroups = db.AnimalGroups.Find(id);
            db.AnimalGroups.Remove(animalGroups);
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
