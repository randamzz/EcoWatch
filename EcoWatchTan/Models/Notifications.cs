namespace EcoWatch.Models
{
    public class Notifications
    {
        public int id;
        public string message { get; set; } = "";
        public string type { get; set; } = "";
        public string cartier { get; set; } = "";

        public Notifications(int id, string message, string type)
        {
            this.id = id;
            this.message = message;
            this.type = type;
            this.cartier = cartier;
        }


    }
}
