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
    public class DeliveriesViewModel
    {
        public List<Delivery>delieveries { get; set; }
        public List<Delivery> delieveriesPast { get; set; }

    }
    public class DeliveriesController : Controller
    {
        private ZOOEntities db = new ZOOEntities();

        // GET: Deliveries
        public ActionResult Index()
        {
            DateTime todaysDate = DateTime.Now;

            //var delivery = db.Delivery.Include(d => d.FoodProducts).Include(d => d.Suppliers).Where();
            var deliveries = from d in db.Delivery.Include(d => d.FoodProducts).Include(d => d.Suppliers)
                           where d.DeliveryDate > todaysDate
                           select d;
            var deliveriesPast = from d in db.Delivery.Include(d => d.FoodProducts).Include(d => d.Suppliers)
                           where d.DeliveryDate < todaysDate
                           select d;
            DeliveriesViewModel data = new DeliveriesViewModel();
            try
            {
                List<Delivery> tDeliveries = new List<Delivery>();
                if (deliveries != null)
                {
                    foreach(Delivery delivery in deliveries)
                    {
                        tDeliveries.Add(delivery);
                    }
                    data.delieveries = tDeliveries;
                }
            }catch(Exception e) { }
            try
            {
                List<Delivery> tDeliveriespast = new List<Delivery>();
                if (deliveriesPast != null)
                {
                    foreach (Delivery delivery in deliveriesPast)
                    {
                        tDeliveriespast.Add(delivery);
                    }
                    data.delieveriesPast = tDeliveriespast;
                }
            }
            catch (Exception e) { }
            return View(data);
        }

        // GET: Deliveries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Delivery delivery = db.Delivery.Find(id);
            if (delivery == null)
            {
                return HttpNotFound();
            }
            return View(delivery);
        }

        // GET: Deliveries/Create
        public ActionResult Create()
        {
            ViewBag.FoodProductsId = new SelectList(db.FoodProducts, "FoodProductsId", "Name");
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "CompanyName");
            return View();
        }

        // POST: Deliveries/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DeliveryId,SupplierId,FoodProductsId,DeliveryDate,Quantity")] Delivery delivery)
        {
            if (ModelState.IsValid)
            {
                db.Delivery.Add(delivery);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FoodProductsId = new SelectList(db.FoodProducts, "FoodProductsId", "Name", delivery.FoodProductsId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "CompanyName", delivery.SupplierId);
            return View(delivery);
        }

        // GET: Deliveries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Delivery delivery = db.Delivery.Find(id);
            if (delivery == null)
            {
                return HttpNotFound();
            }
            ViewBag.FoodProductsId = new SelectList(db.FoodProducts, "FoodProductsId", "Name", delivery.FoodProductsId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "CompanyName", delivery.SupplierId);
            return View(delivery);
        }

        // POST: Deliveries/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DeliveryId,SupplierId,FoodProductsId,DeliveryDate,Quantity")] Delivery delivery)
        {
            if (ModelState.IsValid)
            {
                db.Entry(delivery).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FoodProductsId = new SelectList(db.FoodProducts, "FoodProductsId", "Name", delivery.FoodProductsId);
            ViewBag.SupplierId = new SelectList(db.Suppliers, "SupplierId", "CompanyName", delivery.SupplierId);
            return View(delivery);
        }

        // GET: Deliveries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Delivery delivery = db.Delivery.Find(id);
            if (delivery == null)
            {
                return HttpNotFound();
            }
            return View(delivery);
        }

        // POST: Deliveries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Delivery delivery = db.Delivery.Find(id);
            db.Delivery.Remove(delivery);
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
