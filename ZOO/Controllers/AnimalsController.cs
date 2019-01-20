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

    public class AnimalsController : Controller
    {
        private ZOOEntities db = new ZOOEntities();

        // GET: Animals
        public ActionResult Index()
        {
            var animals = db.Animals.Include(a => a.AnimalGroups);
            return View(animals.ToList());
        }

        // GET: Animals/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animals animals = db.Animals.Find(id);
            if (animals == null)
            {
                return HttpNotFound();
            }
            return View(animals);
        }

        // GET: Animals/Create
        public ActionResult Create()
        {
            ViewBag.AnimalGroupId = new SelectList(db.AnimalGroups, "AnimalGroupId", "Name");
            return View();
        }

        // POST: Animals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AnimalGroupId,Name,Species,BirthDate,Sex")] Animals animals)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Exception = null;
                string msg = null;
                db.Animals.Add(animals);
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    if(e.InnerException == null)
                    {
                        
                        msg = "Niepoprawne dane zwierzęcia";
                        
                        
                    }
                    else
                    {
                        msg = e.InnerException.InnerException.Message;
                    }
                    ViewBag.Exception = msg;
                    ViewBag.AnimalGroupId = new SelectList(db.AnimalGroups, "AnimalGroupId", "Name");

                    //return RedirectToAction("Index","Error");
                    return View(animals);
                    
                    
                }

                return RedirectToAction("Index");
            }

            ViewBag.AnimalGroupId = new SelectList(db.AnimalGroups, "AnimalGroupId", "Name", animals.AnimalGroupId);
            return View(animals);
        }

        // GET: Animals/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animals animals = db.Animals.Find(id);
            if (animals == null)
            {
                return HttpNotFound();
            }
            ViewBag.AnimalGroupId = new SelectList(db.AnimalGroups, "AnimalGroupId", "Name", animals.AnimalGroupId);
            return View(animals);
        }

        // POST: Animals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AnimalId,AnimalGroupId,Name,Species,BirthDate,DeathDate,Sex")] Animals animals)
        {
            ViewBag.Exception = null;
                string msg = null;
            if (ModelState.IsValid)
            {
                db.Entry(animals).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    if (e.InnerException == null)
                    {

                        msg = "Niepoprawne dane zwierzęcia";


                    }
                    else
                    {
                        msg = e.InnerException.InnerException.Message;
                    }
                    ViewBag.Exception = msg;
                    ViewBag.AnimalGroupId = new SelectList(db.AnimalGroups, "AnimalGroupId", "Name");

                    //return RedirectToAction("Index","Error");
                    return View(animals);
                }
                    return RedirectToAction("Index");
            }
            ViewBag.AnimalGroupId = new SelectList(db.AnimalGroups, "AnimalGroupId", "Name", animals.AnimalGroupId);
            return View(animals);
        }

        // GET: Animals/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Animals animals = db.Animals.Find(id);
            if (animals == null)
            {
                return HttpNotFound();
            }
            return View(animals);
        }

        // POST: Animals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Animals animals = db.Animals.Find(id);
            db.Animals.Remove(animals);
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
