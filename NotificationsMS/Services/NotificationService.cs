using MongoDB.Driver;
using NotificationsMS.Controllers;
using NotificationsMS.Models;

namespace NotificationsMS.Services
{
    public class NotificationService
    {
        private IMongoCollection<InfoNotification> _infoNotifications;

        public NotificationService(INotiSettings settings)
        {
            var client =new MongoClient(settings.Server);
            var database = client.GetDatabase(settings.Database);
            _infoNotifications = database.GetCollection<InfoNotification>(settings.Collection);
        }

        public List<InfoNotification> Get() {
        
            return _infoNotifications.Find(d => d.Title !=null).ToList();
        }
        public InfoNotification Create(InfoNotification infoNotification)
        {
            _infoNotifications.InsertOne(infoNotification);

            return infoNotification;
        }
        public void Update(string id, InfoNotification infoNotification)
        {
            _infoNotifications.ReplaceOne(infoNotification => infoNotification.Id == id, infoNotification);

            
        }
        public void Delete(string id)
        {
            _infoNotifications.DeleteOne(d => d.Id == id);

        }


    }
}
