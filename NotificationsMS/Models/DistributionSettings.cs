namespace NotificationsMS.Models
{

    public class DistributionSettings  : IDistributionNotification
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public string Collection { get; set; }

    }

    public interface IDistributionNotification
    {
        string Server { get; set; }
        string Database { get; set; }
        string Collection { get; set; }
    }


}
