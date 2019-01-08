using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZOO.Models;
using System.Data.Entity;

namespace ZOO.Controllers
{
    public class FeedingReminderController : Controller
    {
        private ZOOEntities db = new ZOOEntities();

        // GET: Feedings
        public ActionResult Index()
        {

            FeedingReminderAccess feedingReminderAccess = new FeedingReminderAccess();

            IEnumerable<FeedingReminder> allReminders = feedingReminderAccess.GetFeedingReminders();
            FeedingReminder[] reminders = allReminders.Cast<FeedingReminder>().ToArray();

            List<int> ids = new List<int>();

            for (int i = 0; i < reminders.Length; i++)
            {
                DateTime myDate = DateTime.Parse(reminders[i].FeedingDate);
                if (reminders[i].WasShown != 0 && myDate.AddMinutes(20) > DateTime.UtcNow)
                {
                    ids.Add(reminders[i].FeedingId);
                }
            }

            var feedings = db.Feedings.Include(f => f.AnimalGroups).Include(f => f.Employees).Include(f => f.FoodProducts).Where(f=>ids.Contains(f.FeedingId));
            return View(feedings.ToList());
        }


    }
}