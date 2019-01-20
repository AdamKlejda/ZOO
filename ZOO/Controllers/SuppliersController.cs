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
    public class SuppliersModelView
    {
        public Suppliers supplier { get; set; }
        public List<Delivery>deliveries { get; set; }
    }
    public class SuppliersController : Controller
    {
        private ZOOEntities db = new ZOOEntities();

        // GET: Suppliers
        public ActionResult Index()
        {
            return View(db.Suppliers.ToList());
        }

        // GET: Suppliers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suppliers suppliers = db.Suppliers.Find(id);
            if (suppliers == null)
            {
                return HttpNotFound();
            }

            SuppliersModelView data = new SuppliersModelView();

            var deliveries = from d in db.Delivery
                         where d.SupplierId == id
                         select d;
            try
            {
                if (deliveries != null)
                {
                    List<Delivery> Tdeliveries = new List<Delivery>();
                    foreach(Delivery delivery in deliveries)
                    {
                        Tdeliveries.Add(delivery);
                    }
                    data.deliveries = Tdeliveries;
                }
            }catch(Exception e) { }

            data.supplier = suppliers;
            return View(data);
        }

        // GET: Suppliers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Suppliers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompanyName,ContactName,Address,City,Country,Phone")] Suppliers suppliers)
        { 

            ViewBag.Exception = null;
            string msg = null;
            if (ModelState.IsValid)
            {
                db.Suppliers.Add(suppliers);
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

                    return View(suppliers);

                }
                return RedirectToAction("Index");
            }

            return View(suppliers);
        }

        // GET: Suppliers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suppliers suppliers = db.Suppliers.Find(id);
            if (suppliers == null)
            {
                return HttpNotFound();
            }
            return View(suppliers);
        }

        // POST: Suppliers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SupplierId,CompanyName,ContactName,Address,City,Country,Phone,RowVersion")] Suppliers suppliers)
        {
            ViewBag.Exception = null;
            string msg = null;
            if (ModelState.IsValid)
            {
                var entity = db.Suppliers.Single(p => p.SupplierId == suppliers.SupplierId);

                if (entity.RowVersion != suppliers.RowVersion)
                {
                    TempData["Exception"] = "Entity was modified by another user. Check values and perform edit action again";
                    return RedirectToAction("Edit");
                }


                entity.RowVersion++;
                entity.CompanyName = suppliers.CompanyName;
                entity.ContactName = suppliers.ContactName;
                entity.Address = suppliers.Address;
                entity.City = suppliers.City;
                entity.Country = suppliers.Country;
                entity.Phone = suppliers.Phone;

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

                    return View(suppliers);

                }
                return RedirectToAction("Index");
            }
            return View(suppliers);
        }

        // GET: Suppliers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Suppliers suppliers = db.Suppliers.Find(id);
            if (suppliers == null)
            {
                return HttpNotFound();
            }
            return View(suppliers);
        }

        // POST: Suppliers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Suppliers suppliers = db.Suppliers.Find(id);
            db.Suppliers.Remove(suppliers);
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
