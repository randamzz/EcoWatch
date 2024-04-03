namespace EcoWatch.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Content { get; set; } = "";
        public int IdUser;
        public Blog (int Id , string Content , int IdUser)
        {
            this.Id = Id;
            this.Content = Content;
            this.IdUser = IdUser;
            
        }
    }
}
