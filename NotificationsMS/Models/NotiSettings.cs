namespace NotificationsMS.Models
{
    public class NotiSettings : INotiSettings
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public string Collection { get; set; }
    }

    public interface INotiSettings 
    {
        string Server { get; set; }
        string Database { get; set; }
        string Collection { get; set; }
    }


}
