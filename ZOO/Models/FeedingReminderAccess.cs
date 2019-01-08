using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System.Collections.Generic;

namespace ZOO.Models
{
    public class FeedingReminderAccess
    {
        MongoClient _client;
        MongoServer _server;
        MongoDatabase _db;
        public FeedingReminderAccess()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _server = _client.GetServer();
            _db = _server.GetDatabase("ZOO_Mongo");
        }
        public IEnumerable<FeedingReminder> GetFeedingReminders()
        {
            return _db.GetCollection<FeedingReminder>("Feedings_Reminders").FindAll();
        }

        public FeedingReminder GetFeedingReminder(ObjectId id)
        {
            var res = Query<FeedingReminder>.EQ(p => p.Id, id);
            return _db.GetCollection<FeedingReminder>("Feedings_Reminders").FindOne(res);
        }
        public FeedingReminder Create(FeedingReminder p)
        {
            _db.GetCollection<FeedingReminder>("Feedings_Reminders").Save(p);

            return p;
        }
        public void Update(ObjectId id, FeedingReminder p)
        {
            p.Id = id;
            var res = Query<FeedingReminder>.EQ(pd => pd.Id, id);
            var operation = Update<FeedingReminder>.Replace(p);
            _db.GetCollection<FeedingReminder>("Feedings_Reminders").Update(res, operation);
        }
        public void Remove(ObjectId id)
        {
            var res = Query<FeedingReminder>.EQ(e => e.Id, id);
            var operation = _db.GetCollection<FeedingReminder>("Feedings_Reminders").Remove(res);
        }


    }
}