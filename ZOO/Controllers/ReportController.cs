using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using System.Net;
using ZOO.Models;

namespace ZOO.Controllers
{
    public class ReportEmployeeViewModel
    {
        public Employees employee { get; set; }
        public List<Cleanings> cleanings { get; set; }
        public List<Feedings> feedings { get; set; }


    }
    public class ReportController : Controller
    {
        private ZOOEntities db = new ZOOEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ReportEmployee(int? id)
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
            DateTime todaysDate = DateTime.Now;
            DateTime lastMont = DateTime.Now.AddMonths(-1);

            var cleanings = from c in db.Cleanings
                            where c.EmployeeId == id && c.CleaningDate > lastMont && c.CleaningDate <todaysDate
                            select c;
            var feedings = from c in db.Feedings
                           where c.EmployeeId == id && c.FeedingDate > lastMont && c.FeedingDate < todaysDate
                           select c;

            ReportEmployeeViewModel data = new ReportEmployeeViewModel();
            data.employee = employees;

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
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "FirstName");

            return View(data);
            
        }

        public ActionResult BusiestEmployees()
        {
            var busiest = from c in db.BusiestEmployees
                          select c;
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "FirstName");

            return View(busiest);
        }

        public ActionResult Food_Report(DateTime datefrom, DateTime dateTo)
        {
            ViewBag.FoodProductsId = new SelectList(db.FoodProducts, "FoodProductsId", "Name");
            var food = db.Food_Report1(datefrom, dateTo);
            return View(food);
        }

        public ActionResult Calories_per_Group(DateTime datefrom, DateTime dateTo)
        {
            ViewBag.AnimalGroupId = new SelectList(db.AnimalGroups, "AnimalGroupId", "Name");
            var callories = db.Calories_per_Group1(datefrom, dateTo);
            return View(callories);
        }
    }
}