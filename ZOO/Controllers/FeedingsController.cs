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
    public class FeedingsController : Controller
    {
        private ZOOEntities db = new ZOOEntities();

        // GET: Feedings
        public ActionResult Index()
        {
            var feedings = db.Feedings.Include(f => f.AnimalGroups).Include(f => f.Employees).Include(f => f.FoodProducts);
            return View(feedings.ToList());
        }

        // GET: Feedings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedings feedings = db.Feedings.Find(id);
            if (feedings == null)
            {
                return HttpNotFound();
            }
            return View(feedings);
        }

        // GET: Feedings/Create
        public ActionResult Create()
        {
            ViewBag.AnimalGroupId = new SelectList(db.AnimalGroups, "AnimalGroupId", "Name");
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "FirstName");
            ViewBag.FoodProductsId = new SelectList(db.FoodProducts, "FoodProductsId", "Name");
            return View();
        }

        // POST: Feedings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FeedingId,AnimalGroupId,EmployeeId,FoodProductsId,TimeForFeeding,FeedingDate,Quantity")] Feedings feedings)
        {
            ViewBag.Exception = null;
            string msg = null;
            FeedingReminderAccess feedingReminderAccess = new FeedingReminderAccess();
            if (ModelState.IsValid)
            {

                db.Feedings.Add(feedings);
                try
                {


                    FoodProducts foodProducts = db.FoodProducts.Single(c => c.FoodProductsId == feedings.FoodProductsId);
                    foodProducts.Quantity = foodProducts.Quantity-feedings.Quantity ?? default(int) ;
                    feedingReminderAccess.Create(new FeedingReminder(feedings.FeedingId, feedings.FeedingDate.ToString(), 0));
                    db.SaveChanges();
                        
                }
                catch (Exception e)
                {
                    
                    msg = "Unable to create such feeding, we have no more such food products";
                    
                    ViewBag.Exception = msg;
                    ViewBag.AnimalGroupId = new SelectList(db.AnimalGroups, "AnimalGroupId", "Name");
                    ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "FirstName");
                    ViewBag.FoodProductsId = new SelectList(db.FoodProducts, "FoodProductsId", "Name");

                    return View(feedings);


                }
                return RedirectToAction("Index");
            }

            ViewBag.AnimalGroupId = new SelectList(db.AnimalGroups, "AnimalGroupId", "Name", feedings.AnimalGroupId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "FirstName", feedings.EmployeeId);
            ViewBag.FoodProductsId = new SelectList(db.FoodProducts, "FoodProductsId", "Name", feedings.FoodProductsId);
            return View(feedings);
        }

        // GET: Feedings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedings feedings = db.Feedings.Find(id);
            if (feedings == null)
            {
                return HttpNotFound();
            }
            ViewBag.AnimalGroupId = new SelectList(db.AnimalGroups, "AnimalGroupId", "Name", feedings.AnimalGroupId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "FirstName", feedings.EmployeeId);
            ViewBag.FoodProductsId = new SelectList(db.FoodProducts, "FoodProductsId", "Name", feedings.FoodProductsId);
            return View(feedings);
        }

        // POST: Feedings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FeedingId,AnimalGroupId,EmployeeId,FoodProductsId,TimeForFeeding,FeedingDate")] Feedings feedings)
        {
            if (ModelState.IsValid)
            {
                db.Entry(feedings).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AnimalGroupId = new SelectList(db.AnimalGroups, "AnimalGroupId", "Name", feedings.AnimalGroupId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "FirstName", feedings.EmployeeId);
            ViewBag.FoodProductsId = new SelectList(db.FoodProducts, "FoodProductsId", "Name", feedings.FoodProductsId);
            return View(feedings);
        }

        // GET: Feedings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Feedings feedings = db.Feedings.Find(id);
            if (feedings == null)
            {
                return HttpNotFound();
            }
            return View(feedings);
        }

        // POST: Feedings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Feedings feedings = db.Feedings.Find(id);
            db.Feedings.Remove(feedings);
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
