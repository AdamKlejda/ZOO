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
    public class CleaningsController : Controller
    {
        private ZOOEntities db = new ZOOEntities();

        // GET: Cleanings
        public ActionResult Index()
        {
            var cleanings = db.Cleanings.Include(c => c.Employees).Include(c => c.Pavilions);
            return View(cleanings.ToList());
        }

        // GET: Cleanings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cleanings cleanings = db.Cleanings.Find(id);
            if (cleanings == null)
            {
                return HttpNotFound();
            }
            return View(cleanings);
        }

        // GET: Cleanings/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "FirstName");
            ViewBag.PavilionId = new SelectList(db.Pavilions, "PavilionId", "Name");
            return View();
        }

        // POST: Cleanings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,PavilionId,CleaningDate,TimeForCleaning")] Cleanings cleanings)
        {

            ViewBag.Exception = null;
            string msg = null;
            if (ModelState.IsValid)
            {
                db.Cleanings.Add(cleanings);
                try
                {
                    db.SaveChanges();

                }
                catch (Exception e)
                {
                   
                   
                    msg = e.InnerException.InnerException.Message;
                    
                    ViewBag.Exception = msg;
                    ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "FirstName");
                    ViewBag.PavilionId = new SelectList(db.Pavilions, "PavilionId", "Name");

                    return View(cleanings);


                }
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "FirstName", cleanings.EmployeeId);
            ViewBag.PavilionId = new SelectList(db.Pavilions, "PavilionId", "Name", cleanings.PavilionId);
            return View(cleanings);
        }

        // GET: Cleanings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cleanings cleanings = db.Cleanings.Find(id);
            if (cleanings == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "FirstName", cleanings.EmployeeId);
            ViewBag.PavilionId = new SelectList(db.Pavilions, "PavilionId", "Name", cleanings.PavilionId);
            return View(cleanings);
        }

        // POST: Cleanings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CleaningId,EmployeeId,PavilionId,CleaningDate,TimeForCleaning,RowVersion")] Cleanings cleanings)
        {
            ViewBag.Exception = null;
            string msg = null;

            if (ModelState.IsValid)
            {
                var entity = db.Cleanings.Single(p => p.CleaningId == cleanings.CleaningId);

                if (entity.RowVersion != cleanings.RowVersion)
                {
                    TempData["Exception"] = "Entity was modified by another user. Check values and perform edit action again";
                    return RedirectToAction("Edit");
                }

                entity.RowVersion++;
                entity.EmployeeId = cleanings.EmployeeId;
                entity.PavilionId = cleanings.PavilionId;
                entity.CleaningDate = cleanings.CleaningDate;
                entity.TimeForCleaning = cleanings.TimeForCleaning;

                db.Entry(entity).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();

                }
                catch (Exception e)
                {
                    if (e.InnerException == null)
                    {
                        msg = e.Message;
                    }
                    else
                        msg = e.InnerException.InnerException.Message;

                    ViewBag.Exception = msg;

                    return View(cleanings);

                }
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "FirstName", cleanings.EmployeeId);
            ViewBag.PavilionId = new SelectList(db.Pavilions, "PavilionId", "Name", cleanings.PavilionId);
            return View(cleanings);
        }

        // GET: Cleanings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cleanings cleanings = db.Cleanings.Find(id);
            if (cleanings == null)
            {
                return HttpNotFound();
            }
            return View(cleanings);
        }

        // POST: Cleanings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cleanings cleanings = db.Cleanings.Find(id);
            db.Cleanings.Remove(cleanings);
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
