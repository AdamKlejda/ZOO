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
    public class FoodProductsController : Controller
    {
        private ZOOEntities db = new ZOOEntities();

        // GET: FoodProducts
        public ActionResult Index()
        {
            return View(db.FoodProducts.ToList());
        }

        // GET: FoodProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodProducts foodProducts = db.FoodProducts.Find(id);
            if (foodProducts == null)
            {
                return HttpNotFound();
            }
            return View(foodProducts);
        }

        // GET: FoodProducts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FoodProducts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FoodProductsId,Name,Quantity,ExpiryDate,Calories")] FoodProducts foodProducts)
        {
            if (ModelState.IsValid)
            {
                db.FoodProducts.Add(foodProducts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(foodProducts);
        }

        // GET: FoodProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodProducts foodProducts = db.FoodProducts.Find(id);
            if (foodProducts == null)
            {
                return HttpNotFound();
            }
            return View(foodProducts);
        }

        // POST: FoodProducts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FoodProductsId,Name,Quantity,ExpiryDate,Calories")] FoodProducts foodProducts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(foodProducts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(foodProducts);
        }

        // GET: FoodProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FoodProducts foodProducts = db.FoodProducts.Find(id);
            if (foodProducts == null)
            {
                return HttpNotFound();
            }
            return View(foodProducts);
        }

        // POST: FoodProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FoodProducts foodProducts = db.FoodProducts.Find(id);
            db.FoodProducts.Remove(foodProducts);
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
