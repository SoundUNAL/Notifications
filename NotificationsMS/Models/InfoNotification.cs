using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace NotificationsMS.Models
{
    public class InfoNotification
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id {  get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

    }
}
