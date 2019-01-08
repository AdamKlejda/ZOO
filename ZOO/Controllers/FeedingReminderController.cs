using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZOO.Models;
using System.Data.Entity;
using System.Web.Mvc;

namespace ZOO.Controllers
{
    public class FeedingReminderController : Controller
    {
        private ZOOEntities db = new ZOOEntities();

        public ActionResult Index()
        {

            FeedingReminderAccess feedingReminderAccess = new FeedingReminderAccess();

            IEnumerable<FeedingReminder> allReminders = feedingReminderAccess.GetFeedingReminders();
            FeedingReminder[] reminders = allReminders.Cast<FeedingReminder>().ToArray();

            List<int> ids = filterIds(reminders);

            var feedings = db.Feedings.Include(f => f.AnimalGroups).Include(f => f.Employees).Include(f => f.FoodProducts).Where(f=>ids.Contains(f.FeedingId));
            return View(feedings.ToList());
        }

        public ActionResult MarkAsShown(int? id)
        {
            FeedingReminderAccess feedingReminderAccess = new FeedingReminderAccess();

            IEnumerable<FeedingReminder> allReminders = feedingReminderAccess.GetFeedingReminders();
            FeedingReminder[] reminders = allReminders.Cast<FeedingReminder>().ToArray();

            for (int i = 0; i < reminders.Length; i++)
            {
                if (reminders[i].FeedingId == id)
                {
                    reminders[i].WasShown = 1;
                    feedingReminderAccess.Update(reminders[i].Id, reminders[i]);
                }

            }

            List<int> ids = filterIds(reminders);

            var feedings = db.Feedings.Include(f => f.AnimalGroups).Include(f => f.Employees).Include(f => f.FoodProducts).Where(f => ids.Contains(f.FeedingId));

            return View(feedings.ToList());
        }

        private List<int> filterIds(FeedingReminder[] reminders) {
            List<int> ids = new List<int>();

            for (int i = 0; i < reminders.Length; i++)
            {
                DateTime myDate = DateTime.Parse(reminders[i].FeedingDate);
                if (myDate == DateTime.Today && reminders[i].WasShown == 0)
                {
                    ids.Add(reminders[i].FeedingId);
                }

            }
            return ids;
        }
    }

   

    
}