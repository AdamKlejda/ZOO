using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ZOO.Models
{
   
        public class FeedingReminder
        {
            public ObjectId Id { get; set; }
            [BsonElement("FeedingId")]
            public int FeedingId { get; set; }
            [BsonElement("FeedingDate")]
            public string FeedingDate { get; set; }
            [BsonElement("WasShown")]
            public int WasShown { get; set; }

        public FeedingReminder(int feedingId, string feedingDate, int wasShown) {
            FeedingId = feedingId;
            FeedingDate = feedingDate;
            WasShown = wasShown;
        }
        }
    }
