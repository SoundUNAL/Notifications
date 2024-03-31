using MongoDB.Driver;
using NotificationsMS.Models;

namespace NotificationsMS.Services
{
    public class DistributionNotiService
    {

        private IMongoCollection<DistributionNotification> _distributionNotification;

        public DistributionNotiService(INotiSettings settings)
        {
            var client = new MongoClient(settings.Server);
            var database = client.GetDatabase(settings.Database);
            _distributionNotification = database.GetCollection<DistributionNotification>(settings.Collection);
        }

        public List<DistributionNotification> Get()
        {

            return _distributionNotification.Find(d => d.IsView=="true"|| d.IsView == "false").ToList();
        }
        public DistributionNotification Create(DistributionNotification distributionNotification)
        {
            _distributionNotification.InsertOne(distributionNotification);

            return distributionNotification;
        }
        public void Update(string id, DistributionNotification distributionNotification)
        {
            _distributionNotification.ReplaceOne(distributionNotification => distributionNotification.Id == id, distributionNotification);


        }
        public void Delete(string id)
        {
            _distributionNotification.DeleteOne(d => d.Id == id);

        }


    }
}
