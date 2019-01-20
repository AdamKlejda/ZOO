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
    public class EmployeesViewModel
    {
        public Employees employee { get; set; }
        public List<Cleanings> cleanings { get; set; }
        public List<Feedings> feedings { get; set; }


    }
    public class EmployeesController : Controller
    {
        private ZOOEntities db = new ZOOEntities();

        // GET: Employees
        public ActionResult Index()
        {
            return View(db.Employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employees employees = db.Employees.Find(id);
            if (employees == null)
            {
                return HttpNotFound();
            }
            var cleanings = from c in db.Cleanings
                            where c.EmployeeId == id
                            select c;
            var feedings = from c in db.Feedings
                            where c.EmployeeId == id
                            select c;

            EmployeesViewModel data = new EmployeesViewModel();
            data.employee = employees;

            if (cleanings != null) {
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
            if (feedings != null)
            {
                ViewBag.Exception = null;
                string msg = null;
                try
                {
                    List<Feedings> Tfeedings = new List<Feedings>();
                    foreach (var feeding in feedings)
                    {

                        Tfeedings.Add(feeding);
                    }
                    data.feedings = Tfeedings;

                }
                catch (Exception e)
                {
                    msg = e.InnerException.InnerException.Message;
                    ViewBag.Exception = msg;
                }
            }


            return View(data);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName,LastName,Salary,Position,login,password")] Employees employees)
        {
            ViewBag.Exception = null;
            string msg = null;

            if (ModelState.IsValid)
            {
                db.Employees.Add(employees);
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

                    return View(employees);

                }
                return RedirectToAction("Index");
            }

            return View(employees);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employees employees = db.Employees.Find(id);
            if (employees == null)
            {
                return HttpNotFound();
            }
            return View(employees);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeId,FirstName,LastName,Salary,Position,login,password,RowVersion")] Employees employees)
        {
            ViewBag.Exception = null;
            string msg = null;

            if (ModelState.IsValid)
            {
                var entity = db.Employees.Single(p => p.EmployeeId == employees.EmployeeId);

                if(entity.RowVersion != employees.RowVersion)
                {
                    TempData["Exception"] = "Entity was modified by another user. Check values and perform edit action again";
                    return RedirectToAction("Edit");
                }

                entity.RowVersion++;
                entity.FirstName = employees.FirstName;
                entity.LastName = employees.LastName;
                entity.Salary = employees.Salary;
                entity.Position = employees.Position;
                entity.login = employees.login;
                entity.password = employees.password;
                



                db.Entry(entity).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();

                }
                catch(Exception e)
                {
                    if (e.InnerException == null)
                    {
                        msg = e.Message;
                    }
                    else
                        msg = e.InnerException.InnerException.Message;

                    ViewBag.Exception = msg;

                    return View(employees);

                }
                return RedirectToAction("Index");


            }
            return View(employees);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employees employees = db.Employees.Find(id);
            if (employees == null)
            {
                return HttpNotFound();
            }
            return View(employees);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employees employees = db.Employees.Find(id);
            db.Employees.Remove(employees);
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
