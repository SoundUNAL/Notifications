using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace NotificationsMS.Models
{
    public class DistributionNotification
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string IsView { get; set; }
        public string usuarioID { get; set; }
    }
}
